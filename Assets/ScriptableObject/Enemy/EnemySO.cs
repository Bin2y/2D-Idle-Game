using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    [field: SerializeField] public float BaseSpeed { get; private set; } = 1f;
    [field: SerializeField] public float WalkSpeedModifier { get; private set; } = 0.225f;
    [field: SerializeField] public float BaseHealth { get; set; } = 100f;
}

[Serializable]
public class EnemyAttackInfoData
{
    [field: SerializeField] public float BaseDamage { get; private set; } = 1f;
    [field: SerializeField] public float DamageModifier { get; set; } = 1f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1f;
    [field: SerializeField] public float EnemyChasingRange { get; private set; } = 10f;

}

[CreateAssetMenu(fileName = "Enemy", menuName = "Charaters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyData EnemyData { get; private set; }
    [field: SerializeField] public EnemyAttackInfoData EnemyAttackInfoData { get; private set; }
    public BigInteger GoldReward;
}
