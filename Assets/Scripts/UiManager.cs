using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

    public GameObject craftingPanel;
    public GameObject inventoryPanel;
    public GameObject upgradePanel;
    // Use this for initialization
    void Awake () {
        craftingPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        upgradePanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CraftingToggle()
    {
        Debug.Log("button clicked");
        craftingPanel.SetActive(!craftingPanel.activeSelf);
    }
    public void InventoryToggle()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        inventoryPanel.GetComponent<InventoryUi>().FetchWeapons();
    }
    public void UpgradeToggle()
    {
        upgradePanel.SetActive(!upgradePanel.activeSelf);
    }
}
