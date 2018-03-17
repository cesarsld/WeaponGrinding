using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUpgradeUi : InventoryUi {

    public override void FetchWeapons()
    { //add remove feature
        int x = 0;
        int y = 0;
        int spacing = 60;
        if (player.inventory.HasChangedInUpgrade() && player.inventory.FetchWeaponsForUpgrade().Count > 0)
        {
            foreach (Weapon weapon in player.FetchWeapons())
            {
                if (!weaponList.Contains(weapon))
                {
                    weaponList.Add(weapon);
                    GameObject panel = Instantiate(WeaponPanel, Content.transform, false);
                    weaponGameObj.Add(panel);
                    panel.GetComponent<WeaponPanelUi>().IsOnUpgradePanel();
                    panel.GetComponent<WeaponPanelUi>().ReceiveWeapon(weapon);
                    panel.transform.localPosition = new Vector3(40 + spacing * x, -40 - spacing * y, 0);
                }
                x++;
                if (x == 9)
                {
                    y++;
                    x = 0;
                }
            }
            RectTransform rt = Content.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, 60 * (y + 1) + 40);
        }
        foreach (GameObject obj in weaponGameObj)
        {
            obj.GetComponent<WeaponPanelUi>().IsOnUpgradePanel();
        }
    }
    public void OnCancelClick()
    {
        gameObject.SetActive(false);
    }
}
