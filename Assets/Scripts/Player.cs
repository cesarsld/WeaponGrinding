using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerData player;
    private Inventory inventory;

	// Use this for initialization
	void Awake () {
        player = new PlayerData(1);
        inventory = new Inventory(player.Id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StoreWeapon (Weapon weapon)
    {
        inventory.StoreWeapon(weapon);
    }
    public void RemoveWeapon (Weapon weapon)
    {
        inventory.RemoveWeapon(weapon);
    }
}
