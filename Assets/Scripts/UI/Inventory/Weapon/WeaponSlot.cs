using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum setType
{
    Quaotient,
    Remainder
}
public class WeaponSlot : MonoBehaviour
{
    [SerializeField] public WeaponSO data;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI quantityText;

    public event Action OnQuantityChangeEvent;

    public Inventory inventory;

    public int index;
    public bool equipped;
    public int quantity; //무기소유 갯수 추후에 합성의 재료로 사용됨

    private void Start()
    {
        OnQuantityChangeEvent += SetQuantityText;
        SetRankText();
    }

    public void SetQuantity(int amount, setType value)
    {
        switch(value)
        {
            case setType.Quaotient:
                quantity += amount;
                break;
            case setType.Remainder:
                quantity = amount;
                break;
        }
        OnQuantityChangeEvent?.Invoke();
    }

    public int GetQuantity()
    {
        return quantity;
    }
    public void OnClickButton()
    {
        inventory.SelectItem(index);
    }

    private void SetRankText()
    {
        rankText.text = data.Rank.ToString(); 
    }
    private void SetQuantityText()
    {
        quantityText.text = quantity.ToString();
    }

    
}
