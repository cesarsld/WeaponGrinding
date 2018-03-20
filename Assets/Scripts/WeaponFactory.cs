using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFactory : MonoBehaviour {

    public Text[] PartText;
    public Text WeaponRarityText;
    public GameObject PartSelector;
    private Player player;

    private Weapon NewWeapon;
    private const int PART_NUMBER = 3;
    private int CraftIndex;
    private readonly int[] NoAttemptsAtIndex ={ 100, 5, 1 };
    private int AttemptNo;
    private bool WeaponCrafted;
    private bool hasBalance;

	void Start () 
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        NewWeapon = new Weapon(PART_NUMBER);
        CraftIndex = 0;
        AttemptNo = 0;
        WeaponCrafted = false;
	}

    public void OnClickRoll()
    {
        if (CraftIndex >= PART_NUMBER) return;
        NewWeapon.WeaponPartList[CraftIndex].RollRarity(0);
        PartText[CraftIndex].text = NewWeapon.WeaponPartList[CraftIndex].Rarity.ToString();
        AttemptNo++;
        if (AttemptNo == NoAttemptsAtIndex[CraftIndex])
        {
            OnClickProceed();
        }
    }

    public void OnClickProceed()
    {
        if (WeaponCrafted) return;
        AttemptNo = 0;
        CraftIndex++;
        if (CraftIndex >= PART_NUMBER)
        {
            WeaponRarityText.text = "Weapon rarity:\n" + NewWeapon.WeaponRarity.ToString();
            player.StoreWeapon(NewWeapon);
            WeaponCrafted = true;
            return;
        }
        PartSelector.transform.position = PartText[CraftIndex].gameObject.transform.position;
    }

    public void OnClickReset () // dev feature, keep ot for openeing panel but remove button
    {
        WeaponCrafted = false;
        NewWeapon = new Weapon(PART_NUMBER);
        CraftIndex = 0;
        PartSelector.transform.position = PartText[CraftIndex].gameObject.transform.position;
        WeaponRarityText.text = "Weapon rarity:\n0";
        foreach (Text text in PartText)
        {
            text.text = "0";
        }
    }
}
