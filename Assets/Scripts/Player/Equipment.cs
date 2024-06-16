using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Player player;
    private WeaponSO currentData;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void Equip(WeaponSO data)
    {
        UnEquip();
        currentData = data;
        player.data.AttackData.BaseDamage *= data.AttackPowerModifierMultiply;
        player.data.AttackData.DamageModifier += data.AttackPowerModifierPlus;
    }


    public void UnEquip()
    {
        if (currentData == null) return;
        player.data.AttackData.BaseDamage /= currentData.AttackPowerModifierMultiply;
        player.data.AttackData.DamageModifier -= currentData.AttackPowerModifierPlus;
    }
}
