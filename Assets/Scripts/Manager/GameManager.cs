using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public Enemy enemy;

    //웨이브 변경 이벤트
    public event Action OnWaveChangeEvent;

    public float minY = -3.6f, minX = -2.4f;
    public float maxY = 3.6f, maxX = 2.5f; //게임진행 최대 맵 크기
    public BigInteger gold { get; set; } = 99999999;
    public int wave { get; set; } = 1;


    public void NextWave()
    {
        wave += 1;
        if(wave % 20 == 0) //20웨이브마다 하나의 몬스터를 추가소환
            SpawnManager.Instance.SpawnEnemy();
        SpawnManager.Instance.SpawnEnemy();
        OnWaveChangeEvent?.Invoke();
    }

}
