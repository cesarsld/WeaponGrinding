using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon {

    public WeaponParts[] WeaponPartList;
    private int UpgradeLevel;
    public int WeaponRarity 
    {
        get
        {
            return WeaponPartList.Sum(part => part.Rarity) / WeaponPartList.Length;
        }
    }

    public Weapon(int count)
    {
        WeaponPartList = new WeaponParts[count];
        for (int i = 0; i < WeaponPartList.Length; i++)
        {
            WeaponPartList[i] = new WeaponParts();
        }
        UpgradeLevel = 0;
    }

    public int GetLevel()
    {
        return UpgradeLevel;
    }

    public void Upgrade()
    {
        UpgradeLevel++;
    }

    public void Degrade (int value)
    {
        UpgradeLevel -= value;
    }
    public void Destroy()
    {
        UpgradeLevel = 0;
    }

}
