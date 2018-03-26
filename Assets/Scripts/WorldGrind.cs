using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldGrind {

    private int World;
    private int TimeTogrind;
    private DateTime StartTimeStamp;
    private DateTime LastTimeStamp;
    private DateTime CurrentTimeStamp;
    private bool IsOn;

    private int[] LootArray;
    private int[] PreviousLootArray;
    private static int[] LootTypeTicks = new int[] {30, 300, 900, 3600, 7200, 14400 };

    private static int[] TimeList = new int[4] { 3600, 5400, 7200, 9000};

    public WorldGrind( int world)
    {
        World = world;
        TimeTogrind = TimeList[World];
        StartTimeStamp = DateTime.Now;
        LastTimeStamp = StartTimeStamp;
        CurrentTimeStamp = StartTimeStamp;
        LootArray = new int[3 + world / 3];
        PreviousLootArray = new int[3 + world / 3];

    }

    public int LatestTimeElapsed()
    {
        DateTime LatestTimeStamp = DateTime.Now;
        int returnTime = LatestTimeStamp.Subtract(LastTimeStamp).Seconds;
        LastTimeStamp = LatestTimeStamp;
        return returnTime;
    }

    public int LastTimeElapsed()
    {
        return LastTimeStamp.Subtract(StartTimeStamp).Seconds;
    }

    private void UpdateLootArray()
    {
        for (int i = 0; i < LootArray.Length; i++)
        {
            PreviousLootArray[i] = LootArray[i];
        }
    }

    public int[] FindLoot()
    {
        UpdateLootArray();
        int time = LatestTimeElapsed() + LastTimeElapsed();
        int[] returnArray = new int[LootArray.Length];
        for (int i = 0; i < LootArray.Length ; i ++)
        {
            LootArray[i] = time / LootTypeTicks[i];
            returnArray[i] = LootArray[i] - PreviousLootArray[i];
        }

        return returnArray;
    }

}
