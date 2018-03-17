using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponPanelUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public GameObject SpriteArray;
    private WeaponFrameArray wp;
    public GameObject WeaponDescription;
    public GameObject CurrentDescription;
    private Weapon weapon;
    public GameObject rootParent;
    
    [SerializeField]private bool isOnUpgradePanel;

    private Image WeaponImage;
    // Use this for initialization
    //public WeaponPanelUi(Weapon _weapon)
    //{
    //    weapon = _weapon;
    //    WeaponDescription = GameObject.Find("Additional information Panel");
    //    isOnUpgradePanel = false;
    //}
    void Awake()
    {
        isOnUpgradePanel = false;
    }
	void Start () {
        WeaponImage = transform.Find("Equipment Image").GetComponent<Image>();
        wp = SpriteArray.GetComponent<WeaponFrameArray>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //modify feature to make the information panel a reusable object that changes position so we don't use instantiate
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
       // WeaponDescription.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
        CurrentDescription = Instantiate(WeaponDescription, transform.root, false);
        CurrentDescription.transform.position = new Vector3(transform.position.x - 110, transform.position.y, transform.position.z);
        //WeaponImage.sprite = wp.SpriteArray[Random.Range(0, wp.SpriteArray.Length)];
        CurrentDescription.transform.Find("Weapon Name").gameObject.GetComponent<Text>().text = "Weapon Name +" + weapon.GetLevel().ToString();
        CurrentDescription.transform.Find("Rarity Text").gameObject.GetComponent<Text>().text = "Weapon rarity: " + weapon.WeaponRarity.ToString();
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Destroy(CurrentDescription);
    }

    public void IsOnUpgradePanel()
    {
        isOnUpgradePanel = true;
    }
    public bool getbool()
    {
        return isOnUpgradePanel;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (isOnUpgradePanel)
        {
            WeaponUpgrading wu = GameObject.Find("WeaponUpgrading").GetComponent<WeaponUpgrading>();
            isOnUpgradePanel = false;
            wu.OnClickTransfer(weapon);
            Destroy(CurrentDescription);
            GameObject.Find("Upgrade Inventory Panel").SetActive(false);
        }
    }

    public void ReceiveWeapon(Weapon _weapon)
    {
        weapon = _weapon;
    }
}
