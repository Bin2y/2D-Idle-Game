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
    public int gold { get; set; }
    public int wave { get; set; } = 1;


    public void NextWave()
    {
        wave += 1;
        SpawnManager.Instance.SpawnEnemy();
        OnWaveChangeEvent?.Invoke();
    }

}
