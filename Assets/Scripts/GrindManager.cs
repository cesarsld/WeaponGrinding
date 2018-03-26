using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GrindManager : MonoBehaviour {

    // for now access player, later have a dictionary of players maybe

    private Dictionary<int, List<WorldGrind>> GrindMap;

    private void Awake()
    {
        GrindMap = new Dictionary<int, List<WorldGrind>>();
    }

    private void Start()
    {
    }

    public void AddPlayerOnMap(Player player)
    {
        GrindMap.Add(player.GetId(), new List<WorldGrind>());
    }

    public void StartGrind(int worldIndex, Player player)
    {
        if (GrindMap.ContainsKey(player.GetId()))
        {
            GrindMap[player.GetId()].Add(new WorldGrind(worldIndex));
        }
    }

    public void EndGrind(Player player)
    {
        if (GrindMap.ContainsKey(player.GetId()))
        {
            GrindMap[player.GetId()].RemoveAt(0);
        }
    }
}
