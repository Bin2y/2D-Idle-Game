using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [field: SerializeField] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f;
    [field: SerializeField][field: Range(0f, 100f)] public float BaseHealth { get; private set; } = 100f;
    [field: SerializeField] public float HealthModifier { get;  set; } = 1f;
    [field: SerializeField] public int HealthRecoverModifier { get; set; } = 1;
    [field: SerializeField] public float BaseShield { get; set; } = 1f;
    [field: SerializeField] public float ShieldModifier { get; set; } = 1f;
}

[Serializable]
public class PlayerAttackInfoData
{
    [field: SerializeField] public float BaseDamage { get; set; } = 1f;
    [field: SerializeField] public float DamageModifier { get; set; } = 1f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1f;
    [field: SerializeField] public float EnemyChasingRange { get; private set; } = 10f;

}

[CreateAssetMenu(fileName = "Player", menuName = "Charaters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerData PlayerData { get; private set; }
    [field: SerializeField] public PlayerAttackInfoData AttackData { get; private set; }
}
