using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    private Health health;

    private void Start()
    {
        health = GetComponentInParent<Health>();
    }
    public void SetHPBar()
    {
        hpBar.fillAmount = (float)health.health/health.maxHealth;
    }

    private void Update()
    {
        SetHPBar();
    }
}
