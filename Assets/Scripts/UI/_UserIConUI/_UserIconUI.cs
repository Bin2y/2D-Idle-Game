using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _UserIconUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI powerText;

    private void Start()
    {

    }

    private void UpdateGoldText()
    {
        goldText.text = GameManager.Instance.gold.ToString();
    }


    private void Update()
    {
        //일단 업데이트로 구현
        UpdateGoldText();
    }

}
