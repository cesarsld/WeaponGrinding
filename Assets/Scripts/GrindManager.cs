using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GrindManager : MonoBehaviour {

    // for now access player, later have a dictionary of players maybe
    //also think of a way to remove player from grindmanager if no grind is done

    private Dictionary<int, Dictionary<int, WorldGrind>> GrindMap;

    private void Awake()
    {
        GrindMap = new Dictionary<int, Dictionary<int, WorldGrind>>();
    }

    private void Start()
    {
    }

    public void AddPlayerOnMap(Player player)
    {
        GrindMap.Add(player.GetId(), new Dictionary<int, WorldGrind>());
    }

    public void StartGrind(int worldIndex, Player player)
    {
        if (GrindMap.ContainsKey(player.GetId()))
        {
            GrindMap[player.GetId()].Add(worldIndex, new WorldGrind(worldIndex));
        }
        else
        {
            AddPlayerOnMap(player);
            StartGrind(worldIndex, player);
        }
    }

    public void TimeGrinded(Player player)
    {
        if (GrindMap.ContainsKey(player.GetId()))
        {
            Debug.Log(GrindMap[player.GetId()][0].LatestTimeElapsed());
        }
    }

    public void EndGrind(Player player, int worldIndex)
    {
        if (GrindMap.ContainsKey(player.GetId()))
        {
            if (GrindMap[player.GetId()].ContainsKey(worldIndex))
            {
                GrindMap[player.GetId()].Remove(worldIndex);
                if (GrindMap[player.GetId()].Count == 0)
                {
                    GrindMap.Remove(player.GetId());
                }
            }
        }
    }
}
