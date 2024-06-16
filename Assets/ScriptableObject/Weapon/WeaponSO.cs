using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Equip/Weapon")]

public class WeaponSO : ScriptableObject
{
    [field: SerializeField] public int AttackPowerModifierPlus;
    [field: SerializeField] public int AttackPowerModifierMultiply;
}
