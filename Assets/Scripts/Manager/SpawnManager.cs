using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] public EnemySO currentData;
    [SerializeField] public EnemySO nextData;

    private void Start()
    {
        //맨처음 1웨이브는 start에있는 EnemyData가져옴 
        currentData = GameManager.Instance.enemy.data;
    }

    //웨이브가 넘어갈떄마다 호출
    public void SetNextEnemyData()
    {
        nextData = currentData;
        nextData.EnemyData.BaseHealth =  + 100f;
        nextData.EnemyAttackInfoData.DamageModifier = currentData.EnemyAttackInfoData.DamageModifier + 3f;
        currentData = nextData;
    }
    //적이 죽으면 해당 동작
    public void SpawnEnemy()
    {
        GameObject go = Instantiate(enemyList[Random.Range(0, enemyList.Count)]);
        float x = Random.Range(GameManager.Instance.minX, GameManager.Instance.maxX);
        float y = Random.Range(GameManager.Instance.minY, GameManager.Instance.maxY);
        go.transform.position = new Vector2(x, y);
        SetNextEnemyData();
        //새로 생성된 Enemy는 다음 웨이브 데이터를 참조
        if (go.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.health.maxHealth = (int)nextData.EnemyData.BaseHealth;
            enemy.data = nextData;
        }
    }
}
