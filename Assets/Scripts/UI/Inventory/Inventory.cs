using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public WeaponSlot[] weaponSlots;

    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Transform weaponSlotPannel;
    [SerializeField] private GameObject equipButton;

    private WeaponSO selectedWeapon;

    public int selectedWeaponIndex;

    private void Start()
    {
        weaponSlots = new WeaponSlot[weaponSlotPannel.childCount];

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            weaponSlots[i] = weaponSlotPannel.GetChild(i).GetComponent<WeaponSlot>();
            weaponSlots[i].index = i;
            weaponSlots[i].inventory = this;
        }
    }
    public void SelectItem(int index)
    {
        if (weaponSlots[index].data == null) return;

        selectedWeapon = weaponSlots[index].data;
        selectedWeaponIndex = index;

        equipButton.SetActive(true);
        infoText.text = $"AttackPower {selectedWeapon.AttackPowerModifierPlus.ToString()} + \n AttackPower {selectedWeapon.AttackPowerModifierMultiply.ToString()} *";
    }
}
