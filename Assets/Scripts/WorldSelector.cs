using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelector : MonoBehaviour {

    private Player player;

    private int WorldIndex;

    public Text WorldText;

    public GameObject WorldPanel;

    private void Awake()
    {
        WorldIndex = 0;
    }
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        WorldPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickIncrementWorld()
    {
        if(WorldIndex < 4)
        {
            WorldIndex++;
            UpdateText();
        }
    }

    public void OnClickDecrementWorld()
    {
        if (WorldIndex > 0)
        {
            WorldIndex--;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        WorldText.text = "World " + (1 + WorldIndex).ToString();
    }

    public void OnClickSelectWorld()
    {
        WorldPanel.SetActive(true);
    }

    public void OnClickStartGrind()
    {
        GrindManager gm = GameObject.Find("GrindMechanic").GetComponent<GrindManager>();
        gm.StartGrind(WorldIndex, player);
    }

    public void OnClickEndGrind()
    {
        GrindManager gm = GameObject.Find("GrindMechanic").GetComponent<GrindManager>();
        gm.EndGrind(player, WorldIndex);
    }
}
