﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

    public GameObject craftingPanel;
    public GameObject inventoryPanel;
    public GameObject upgradePanel;
    public GameObject upgradeInventoryPanel;
    public GameObject SelectorPanel;
    private bool panelSelected;
    // Use this for initialization
    void Awake () {
        craftingPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        upgradePanel.SetActive(false);
        upgradeInventoryPanel.SetActive(false);
        SelectorPanel.SetActive(false);
        panelSelected = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CraftingToggle()
    {
        if (!panelSelected)
        {
            craftingPanel.SetActive(!craftingPanel.activeSelf);
            GameObject.Find("WeaponFactory").GetComponent<WeaponFactory>().OnClickReset();
            panelSelected = !panelSelected;
        }
    }
    public void InventoryToggle()
    {
        if (!panelSelected)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            if (inventoryPanel.activeSelf) inventoryPanel.GetComponent<InventoryUi>().FetchWeapons();
            panelSelected = !panelSelected;
        }
    }
    public void UpgradeToggle()
    {
        if (!panelSelected)
        {
            upgradePanel.SetActive(!upgradePanel.activeSelf);
            GameObject.Find("WeaponUpgrading").GetComponent<WeaponUpgrading>().UpdateGemcount();
            panelSelected = !panelSelected;
        }
    }

    public void UpgradeInventoryToggle()
    {
         upgradeInventoryPanel.SetActive(!upgradeInventoryPanel.activeSelf);
        if (upgradeInventoryPanel.activeSelf) upgradeInventoryPanel.GetComponent<InventoryUpgradeUi>().FetchWeapons();

    }

    public void SelectorToggle()
    {
        if (!panelSelected)
        {
            SelectorPanel.SetActive(!craftingPanel.activeSelf);
            panelSelected = !panelSelected;
        }
    }

    public void PanelClosed()
    {
        panelSelected = false;
    }
}
