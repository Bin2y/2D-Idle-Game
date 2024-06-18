using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _UserIconUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI waveText;

    private void Start()
    {
        GameManager.Instance.OnWaveChangeEvent += UpdateWaveText;
    }
    private void Update()
    {
        //일단 업데이트로 구현
        UpdateGoldText();
        UpdatePowerText();
    }
    private void UpdateGoldText()
    {
        goldText.text = GameManager.Instance.gold.BigIntergerToUnit();
    }
    private void UpdatePowerText()
    {
        powerText.text = (GameManager.Instance.player.data.AttackData.DamageModifier +
                         GameManager.Instance.player.data.PlayerData.HealthModifier +
                         GameManager.Instance.player.data.PlayerData.ShieldModifier +
                         GameManager.Instance.player.data.PlayerData.HealthRecoverModifier).ToString();
    }
    private void UpdateWaveText()
    {
        waveText.text = "Wave : " + GameManager.Instance.wave.ToString();

    }



}
