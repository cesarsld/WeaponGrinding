using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    private int playerID;
    private List<Weapon> WeaponList;
    public Resource[] ResourceBag;
    private bool hasChanged;
    private bool hasChangedInUpgrade;
   
    public Inventory(int id)
    {
        playerID = id;
        WeaponList = new List<Weapon>();
        ResourceBag = new Resource[Enum.GetNames(typeof(Resources)).Length];
        for (int i = 0; i < ResourceBag.Length; i++)
        {
            ResourceBag[i] = new Resource((Resources)i);
        }
        hasChanged = false;
        hasChangedInUpgrade = false;
    }

    public void LoadDataFromDB ()
    {
        int n = Enum.GetNames(typeof(Resources)).Length;
    }

    public List<Weapon> FetchWeapons()
    {
        hasChanged = false;
        return WeaponList;
    }

    public List<Weapon> FetchWeaponsForUpgrade()
    {
        hasChangedInUpgrade = false;
        return WeaponList;
    }

    public void StoreWeapon (Weapon weapon)
    {
        WeaponList.Add(weapon);
        hasChanged = true;
        hasChangedInUpgrade = true;

    }
    public void RemoveWeapon (Weapon weapon)
    {
        WeaponList.Remove(weapon);
        hasChanged = true;
        hasChangedInUpgrade = true;
    }

    public bool HasChanged()
    {
        return hasChanged;
    }
    public bool HasChangedInUpgrade()
    {
        return hasChangedInUpgrade;
    }

}
