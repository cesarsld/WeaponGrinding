﻿using System.Collections;
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
        WeaponDescription = GameObject.Find("Additional information Panel");
    }
	void Start () {
        WeaponImage = transform.Find("Equipment Image").GetComponent<Image>();
        wp = SpriteArray.GetComponent<WeaponFrameArray>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        CurrentDescription = Instantiate(WeaponDescription, transform.root, false);
        CurrentDescription.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
        Debug.Log(CurrentDescription.transform.parent);
        WeaponImage.sprite = wp.SpriteArray[Random.Range(0, wp.SpriteArray.Length)];
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Destroy(CurrentDescription);
    }
}
