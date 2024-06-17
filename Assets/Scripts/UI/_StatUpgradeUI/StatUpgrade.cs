using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUpgrade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldValueText;
    [SerializeField] private UpgradeStatSO upgradeStatSO;
    [SerializeField] private UpgradePannelUI upgradePannelUI;

    private void Start()
    {
        SetGoldValueText();
    }
    public void OnUpgrade()
    {
        switch (upgradeStatSO.UpgradeStat)
        {
            case (UpGradeStat.Attack):
                if (!CanUpgrade())
                {
                    NoMoneyAlertOnLog(); 
                    break;
                }
                upgradeStatSO.Attack += 10;
                GameManager.Instance.player.data.AttackData.DamageModifier += 10;
                PayPrice();
                break;
            case (UpGradeStat.Shield):
                if (!CanUpgrade())
                {
                    NoMoneyAlertOnLog();
                    break;
                }
                upgradeStatSO.Shield += 10;
                GameManager.Instance.player.data.PlayerData.ShieldModifier += 10;
                PayPrice();
                break;
            case (UpGradeStat.Health):
                if (!CanUpgrade())
                {
                    NoMoneyAlertOnLog();
                    break;
                }
                upgradeStatSO.Health += 10;
                GameManager.Instance.player.data.PlayerData.HealthModifier += 10;
                PayPrice();
                break;
            case (UpGradeStat.Recover):
                if (!CanUpgrade())
                {
                    NoMoneyAlertOnLog();
                    break;
                }
                upgradeStatSO.Recover += 5;
                GameManager.Instance.player.data.PlayerData.HealthRecoverModifier += 10;
                PayPrice();
                break;
        }
        SetGoldValueText();
        upgradePannelUI.updatedStatUI.SetUpgradeStat();
    }
    public void NoMoneyAlertOnLog()
    {
        Debug.Log("돈이 부족합니다");
    }

    public void SetGoldValueText()
    {
        goldValueText.text = upgradeStatSO.price.BigIntergerToUnit();
    }

    //가진 돈과 비교해서 Upgrade가능여부 판단
    public bool CanUpgrade()
    {
        return upgradeStatSO.price <= GameManager.Instance.gold;
    }

    public void PayPrice()
    {
        GameManager.Instance.gold -= upgradeStatSO.price;
    }

}
