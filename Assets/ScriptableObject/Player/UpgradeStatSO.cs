using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpGradeStat
{
    Attack,
    Shield,
    Health,
    Recover,
    All //최종적으로 4개의 변화 스텟이 모인 데이터를 수집할 곳
}
[CreateAssetMenu(fileName = "UpgradeStat", menuName = "Util/UpgradeStat")]
public class UpgradeStatSO : ScriptableObject
{
    //플레이어의 Modifier에 데이터를 붙혀서 작동하게끔 설계할것
    [field: SerializeField] public UpGradeStat UpgradeStat;
    [field: SerializeField] public float Attack;
    [field: SerializeField] public float Shield;
    [field: SerializeField] public float Health;
    [field: SerializeField] public int Recover;
    public BigInteger price = 100;
}
