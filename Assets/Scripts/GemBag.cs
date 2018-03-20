using System.Collections;
using System.Collections.Generic;
using System;

public class GemBag {
    //Crystal
    //Rubies
    //Diamonds
    //Runic Stones
    private int playerId;
    private int[] Gem = new int[4];

    public GemBag(int _playerId)
    {
        playerId = _playerId;
        for (int i = 0; i < 4; i++)
        {
            Gem[i] = 999;
        }
    }

    public void Use(int gemIndex, int value)
    {
        Gem[gemIndex] -= value;
    }
    public void Add(int gemIndex, int value)
    {
        Gem[gemIndex] += value;
    }

    public int GetGemCount(int gemIndex)
    {
        return Gem[gemIndex];
    }
}
