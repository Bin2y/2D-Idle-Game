using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Common,
    UnCommon,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Equip/Weapon")]
public class WeaponSO : ScriptableObject
{
    public EquipType equipType;
    [field: SerializeField][field: Range(1, 5)] public int Rank;
    [field: SerializeField] public int AttackPowerModifierPlus;
    [field: SerializeField] public int AttackPowerModifierMultiply;
}
