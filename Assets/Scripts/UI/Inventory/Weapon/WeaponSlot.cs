using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] public WeaponSO data;

    public Inventory inventory;

    public int index;
    public bool equipped;
    public int quantity;




    public void OnClickButton()
    {
        inventory.SelectItem(index);
    }
}
