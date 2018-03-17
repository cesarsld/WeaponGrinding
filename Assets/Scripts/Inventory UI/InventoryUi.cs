using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour {

    public GameObject WeaponPanel;
    public GameObject Content;
    protected Player player;
    protected List<Weapon> weaponList;
    protected List<GameObject> weaponGameObj;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player").GetComponent<Player>();
        weaponList = new List<Weapon>();
        weaponGameObj = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void FetchWeapons()
    { //add remove feature
        int x = 0;
        int y = 0;
        int spacing = 60;

        if (player.inventory.HasChanged() && player.FetchWeapons().Count > 0)
        {
            foreach (Weapon weapon in player.FetchWeapons())
            {
                if (!weaponList.Contains(weapon))
                {
                    weaponList.Add(weapon);
                    GameObject panel = Instantiate(WeaponPanel, Content.transform, false);
                    panel.GetComponent<WeaponPanelUi>().ReceiveWeapon(weapon);
                    panel.transform.localPosition = new Vector3(40 + spacing * x, -40 - spacing * y, 0);
                }
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
}
