using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    private int playerID;
    private List<Weapon> WeaponList;
    private GemBag gemBag;
    private bool hasChanged;
    private bool hasChangedInUpgrade;
   
    public Inventory(int id)
    {
        playerID = id;
        WeaponList = new List<Weapon>();
        hasChanged = false;
        hasChangedInUpgrade = false;
    }

    public void LoadDataFromDB ()
    {
        
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
