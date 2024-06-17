using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int health;
    public event Action OnDie;

    public bool IsDie = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public IEnumerator RecoverHealth(int amount)
    {
        health += 1;
        health = Mathf.Min(health, maxHealth);
        yield return new WaitForSeconds(1);
    }
    public void TakeDamage(int damage)
    {
        if (health == 0) return;
        health = Mathf.Max(health - damage, 0);

        if (health == 0)
        {
            OnDie?.Invoke();
            IsDie = true;
            Destroy(gameObject);
        }
    }
    //아래는 Enemy가 사용하는 TakeKdamage 플레이어의 shield까지 포함되어 간단하게 계산하는방식
    public void TakeDamage(int damage, int shield)
    {
        if (health == 0) return;
        health = Mathf.Min(Mathf.Max(health - damage + shield, 0),maxHealth);

        if (health == 0)
        {
            OnDie?.Invoke();
            IsDie = true;
            Destroy(gameObject);
        }
    }
}
