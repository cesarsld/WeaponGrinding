using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParts 
{
    public int Rarity;
    public Sprite sprite;


    public WeaponParts()
    {}

    public void RollRarity(int rngDamper)
    {
        Rarity = Random.Range(rngDamper, 100);  
    }

}
