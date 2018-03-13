using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponPanelUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject SpriteArray;
    private WeaponFrameArray wp;
    public GameObject WeaponDescription;
    public GameObject CurrentDescription;
    private Weapon weapon;
    public GameObject rootParent;

    private Image WeaponImage;
    // Use this for initialization
    public WeaponPanelUi(Weapon _weapon)
    {
        weapon = _weapon;
    }
	void Start () {
        //WeaponDescription.SetActive(false);
        WeaponImage = transform.Find("Equipment Image").GetComponent<Image>();
        wp = SpriteArray.GetComponent<WeaponFrameArray>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //WeaponDescription.SetActive(true);
        CurrentDescription = Instantiate(WeaponDescription, rootParent.transform, false);
        Debug.Log(CurrentDescription.transform.parent);
        WeaponImage.sprite = wp.SpriteArray[Random.Range(0, wp.SpriteArray.Length)];
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //WeaponDescription.SetActive(false);
        //Destroy(CurrentDescription);
    }
}
