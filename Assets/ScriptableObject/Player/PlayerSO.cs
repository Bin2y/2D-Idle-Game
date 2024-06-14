using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    [field: SerializeField] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f;
    [field: SerializeField][field: Range(0f, 100f)] public float BaseHealth { get; private set; } = 100f;
}
public class PlayerAttackInfoData
{
    [field: SerializeField] public float BaseDamage { get; private set; } = 1f;
    [field: SerializeField][field: Range(0f, 2f)] public float DamageModifier { get; private set; } = 1f;
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float EnemyChasingRange { get; private set; } = 100f;

}
[CreateAssetMenu(fileName = "Player", menuName = "Charaters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerData PlayerData { get; private set; }
    [field: SerializeField] public PlayerAttackInfoData AttackData { get; private set; }
}
