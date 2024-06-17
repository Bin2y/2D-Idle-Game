using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatedStatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI recoverText;

    private void Start()
    {
        SetUpgradeStat();
    }
    public void SetUpgradeStat()
    {
        attackText.text = "Attack+ : " + GameManager.Instance.player.data.AttackData.DamageModifier.ToString();
        defText.text = "Def+ : " + GameManager.Instance.player.data.PlayerData.ShieldModifier.ToString();
        HPText.text = "HP+ : " + GameManager.Instance.player.data.PlayerData.HealthModifier.ToString();
        recoverText.text = "Recover+ :" + GameManager.Instance.player.data.PlayerData.HealthRecoverModifier.ToString();
    }
}
