using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUpgradeUi : MonoBehaviour {

    public GameObject WeaponPanel;
    public GameObject Content;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void FetchWeapons()
    { // later on this function will fetch weapons from inventory
        int x = 0;
        int y = 0;
        int spacing = 60;
        for (int i = 0; i < 28; i++)
        {
            GameObject panel = Instantiate(WeaponPanel, Content.transform, false);
            panel.transform.localPosition = new Vector3(40 + spacing * x , -40 - spacing * y, 0);
            x++;
            if (x == 3)
            {
                y++;
                x = 0;
            }
        }
        RectTransform rt = Content.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 60 * (y + 1) + 40);
    }
}
