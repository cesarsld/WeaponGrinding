using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Resources
{
    Wood,
    Iron,
    Steel,
    Mithril,
    Runite
}

public class Resource
{
    private Resources Name;
    private int Count;

    public Resource(Resources resource)
    {
        Name = resource;
        Count = 0;
    }

    public int GetCount()
    {
        return Count;
    }

    public Resources GetName()
    {
        return Name;
    }

    public void AddCount(int resources)
    {
        Count += resources;
    }

    public void UseCount(int resource)
    {
        Count -= resource;
    }
}

