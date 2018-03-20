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

    private Player player;

    private bool weaponSelected;
    public Text UpgradeLevelText;
    public Text SuccessRateText;
    public Text WeaponRarityText;

    public Text[] GemCountTextArray;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        weaponSelected = false;
	}
	
    public void OnClickUpgrade()
    {
        if (!weaponSelected) return;
        if (HasGems())
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
                    player.RemoveWeapon(WeaponToUpgrade);
                    weaponSelected = true;
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
            UpdateGemcount();
        }
    }

    public void OnClickTransfer(Weapon weapon)
    {
        weaponSelected = true;
        WeaponToUpgrade = weapon;
        UpgradeLevelText.text = "Weapon level:\n" + WeaponToUpgrade.GetLevel().ToString();
        SuccessRateText.text = "Success rate:\n" + SuccessRateArray[WeaponToUpgrade.GetLevel()].ToString() + "%";
        WeaponRarityText.text = "Weapon rarity :\n" + WeaponToUpgrade.WeaponRarity.ToString();
    }

    //subject ot change, for now only one gem per upgrade
    private bool HasGems()
    {
        int index = WeaponToUpgrade.GetLevel() / 4;
        if (player.gemBag.GetGemCount(index) > 0)
        {
            player.gemBag.Use(index, 1);
            return true;
        }
        return false;
    }
    public void UpdateGemcount()
    {
        for(int i = 0; i < GemCountTextArray.Length; i++)
        {
            GemCountTextArray[i].text = player.gemBag.GetGemCount(i).ToString();
        }
    }
}
