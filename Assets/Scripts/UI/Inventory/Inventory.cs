using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public int curEquipIndex;

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

        //선택된게 장착이되어있으면 장착버튼 비활성화
        if (!weaponSlots[selectedWeaponIndex].equipped)
            equipButton.SetActive(true);
        else equipButton.SetActive(false);
        infoText.text = $"AttackPower {selectedWeapon.AttackPowerModifierPlus.ToString()} + \n AttackPower {selectedWeapon.AttackPowerModifierMultiply.ToString()} *";
    }

    public void OnEquipButton()
    {
        if (weaponSlots[selectedWeaponIndex].quantity == 0) return;//갯수가 0개면 장착불가능
        if (weaponSlots[curEquipIndex].equipped)
        {
            UnEquip(curEquipIndex);
        }
        GameManager.Instance.player.equipment.Equip(weaponSlots[selectedWeaponIndex].data);
        weaponSlots[selectedWeaponIndex].equipped = true;
        curEquipIndex = selectedWeaponIndex;
        equipButton.SetActive(false);
    }

    void UnEquip(int index)
    {
        weaponSlots[index].equipped = false;
        //UpdateUI();

        if (selectedWeaponIndex == index)
        {
            SelectItem(selectedWeaponIndex);
        }
    }

    public int synthesisQuantityMax = 25;
    //일괄합성버튼 나중에 리팩토링할때 클래스로 따로 빼도 괜찮을것 같다.
    public void OnSynthesisAll()
    {
        int quaotient;
        int remainder;
        for (int i = 0; i < weaponSlots.Length - 1; i++)
        {
            quaotient = 0;
            remainder = 0;
            if (weaponSlots[i].quantity < synthesisQuantityMax) continue;
            if (weaponSlots[i].quantity / synthesisQuantityMax != 0)
            {
                quaotient = weaponSlots[i].GetQuantity() / synthesisQuantityMax;
                remainder = weaponSlots[i].GetQuantity() % synthesisQuantityMax;
            }
            weaponSlots[i].SetQuantity(remainder,setType.Remainder);
            weaponSlots[i + 1].SetQuantity(quaotient, setType.Quaotient);
        }
    }
}

