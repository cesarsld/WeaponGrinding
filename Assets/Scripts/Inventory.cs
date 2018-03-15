using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public int playerID;
    private List<Weapon> WeaponList;
   
    public Inventory(int id)
    {
        playerID = id;
    }

    public void LoadDataFromDB ()
    {
        
    }

    public List<Weapon> FetchWeapons()
    {
        return WeaponList;
    }

    public void StoreWeapon (Weapon weapon)
    {
        WeaponList.Add(weapon);
    }
    public void RemoveWeapon (Weapon weapon)
    {
        WeaponList.Remove(weapon);
    }

}
