using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgrading : MonoBehaviour {

    private readonly int[] SuccessRateArray =
        {//later in the project migrate data in xml files
            //crystals
            100,
            100,
            100,
            90,
            //rubies
            80,
            80,
            80,
            70,
            //diamonds
            60,
            60,
            60,
            50,
            //runic stones
            40,
            20,
            10
        };

    private Weapon WeaponToUpgrade;

    public Text UpgradeLevelText;
    public Text SuccessRateText;
    public Text WeaponRarityText;

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnClickUpgrade()
    {
        int rollChance = Random.Range(0, 99);
        if (rollChance < SuccessRateArray[WeaponToUpgrade.GetLevel()])
        {
            WeaponToUpgrade.Upgrade();
            if (WeaponToUpgrade.GetLevel() <= 15)
            {
                SuccessRateText.text = "Success rate:\n" + SuccessRateArray[WeaponToUpgrade.GetLevel()].ToString() + "%";
            }
        }
        else
        {
            if (WeaponToUpgrade.GetLevel() > 7)
            {
                WeaponToUpgrade.Destroy();
                UpgradeLevelText.text = "Weapon level:\n" + WeaponToUpgrade.GetLevel().ToString();
                return;
            }
            switch (WeaponToUpgrade.GetLevel())
            {
                case 3:
                case 4:
                case 5:
                case 6:
                    WeaponToUpgrade.Degrade(1);
                    break;
                case 7:
                    WeaponToUpgrade.Degrade(4);
                    break;
            }
        }
        UpgradeLevelText.text = "Weapon level:\n" + WeaponToUpgrade.GetLevel().ToString();
    }

    public void OnClickTransfer()
    {
        WeaponToUpgrade = GameObject.Find("WeaponFactory").GetComponent<WeaponFactory>().OnClickWeaponTransfer();
        UpgradeLevelText.text = "Weapon level:\n" + WeaponToUpgrade.GetLevel().ToString();
        SuccessRateText.text = "Success rate:\n" + SuccessRateArray[WeaponToUpgrade.GetLevel()].ToString() + "%";
        WeaponRarityText.text = "Weapon rarity :\n" + WeaponToUpgrade.WeaponRarity.ToString();
    }
}
