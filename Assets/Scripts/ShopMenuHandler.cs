using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenuHandler : MonoBehaviour
{
    public Player player;

    public int swimPowerPrice;
    public int rotationSpeedPrice;
    public int timePrice;

    public TextMeshProUGUI swimPowerPriceText;
    public TextMeshProUGUI rotationSpeedPriceText;
    public TextMeshProUGUI timePriceText;



    void Start()
    {

    }

    void Update()
    {
        
    }



    public void BuySwimPower()
    {
        if (player.instanceMaster.GetCurrency() >= swimPowerPrice)
        {
            player.pushForce += 100;

            player.instanceMaster.SubtractFromCurrency(swimPowerPrice);
            player.instanceMaster.shopTrashCurrencyText.text = "Trash Currency: " + player.instanceMaster.GetCurrency();

            swimPowerPrice *= 2;
            swimPowerPriceText.text = swimPowerPrice + " trash";
        }
    }

    public void BuyRotationSpeed()
    {
        if (player.instanceMaster.GetCurrency() >= rotationSpeedPrice)
        {
            player.rotateSpeed += 40;

            player.instanceMaster.SubtractFromCurrency(rotationSpeedPrice);
            player.instanceMaster.shopTrashCurrencyText.text = "Trash Currency: " + player.instanceMaster.GetCurrency();

            rotationSpeedPrice *= 2;
            rotationSpeedPriceText.text = rotationSpeedPrice + " trash";
        }
    }

    public void BuyTime()
    {
        if (player.instanceMaster.GetCurrency() >= timePrice)
        {
            player.instanceMaster.AddToTimer(10);

            player.instanceMaster.SubtractFromCurrency(timePrice);
            player.instanceMaster.shopTrashCurrencyText.text = "Trash Currency: " + player.instanceMaster.GetCurrency();

            timePrice *= 2;
            timePriceText.text = timePrice + " trash";
        }
    }
}