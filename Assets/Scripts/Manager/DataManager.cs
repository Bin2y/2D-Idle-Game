using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEditor;
using UnityEngine;

//전역에서 접근하여 데이터를 저장할 수 있도록
public class DataManager : Singleton<DataManager>
{
    public PlayerSO playerData;
    public EnemySO enemyData;
    public int waveData;
    public BigInteger goldData;

    private readonly string PlayerDataPath = "PlayerData.json";

    public void OnSaveButtonClicked()
    {
        Save();
    }

    public void OnLoadButtonClicked()
    {
        Load();
    }

    public void Save()
    {
        playerData = GameManager.Instance.player.data;
        enemyData = GameManager.Instance.enemy.data;
        waveData = GameManager.Instance.wave;
        goldData = GameManager.Instance.gold;
        SavePlayerData();
    }

    public void Load()
    {
        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(Path.Combine(Application.dataPath, PlayerDataPath), data);
        Debug.Log("Save Player Data");
    }

    public void LoadPlayerData()
    {
        string path = Path.Combine(Application.dataPath, PlayerDataPath);
        string data = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerSO>(data);
        Debug.Log("Load Player Data");
    }
}
