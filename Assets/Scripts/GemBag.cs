using System.Collections;
using System.Collections.Generic;
using System;

public class GemBag {
    private int[] Gem = new int[4];

    public void Use(int gemIndex, int value)
    {
        Gem[gemIndex] -= value;
    }
    public void Add(int gemIndex, int value)
    {
        Gem[gemIndex] += value;
    }
}
