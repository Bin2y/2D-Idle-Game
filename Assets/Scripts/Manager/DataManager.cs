using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전역에서 접근하여 데이터를 저장할 수 있도록
public class DataManager : Singleton<DataManager>
{
    public PlayerSO playerData;
    public EnemySO enemyData;

    public void OnSaveButtonClicked()
    {
        
    }

    public void Save()
    {
        playerData = GameManager.Instance.player.data;
        enemyData = GameManager.Instance.enemy.data;
    }
}
