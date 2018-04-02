using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {

    //further down the line put all values in a file

    private GrindManager grindManager;
    private static int[][] LootTable ={
        new int[]{600, 998},
        new int[]{500, 996},
        new int[]{400, 992},
        new int[]{300, 984},
        new int[]{200, 970},
        new int[]{100, 950},
    };
    //private Player player;

	void Start () {
        grindManager = GameObject.Find("GrindMechanic").GetComponent<GrindManager>();
        //player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FindLoot(Player player, int[] LootTicks, int world)
    {

        for (int i = 0; i < LootTicks.Length; i++)
        {
            int roll = Random.Range(0, 999);
            if (roll > LootTable[i][0])
            {
                AddGem(player);
            }
            else if (roll > LootTable[i][1])
            {
                player.inventory.ResourceBag[world].AddCount(1);
            }
        }
    }

    private void AddGem(Player player)
    {
        int gem = 0;
        int gemroll = Random.Range( 0, 9);
        switch (gemroll)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                gem = 0;
                break;
            case 4:
            case 5:
            case 6:
                gem = 1;
                break;
            case 7:
            case 8:
                gem = 2;
                break;
            case 9:
                gem = 3;
                break;

        }
        player.gemBag.Add(gem, 1);
    }

    private bool LootAttempt()
    {

        return true;
    }

}
