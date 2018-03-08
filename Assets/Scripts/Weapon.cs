using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon {
//    public WeaponParts SwordGrip;
//    public WeaponParts SwordCrossGuard;
//    public WeaponParts SwordBlade;
    public WeaponParts[] WeaponPartList;
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
    }

}
