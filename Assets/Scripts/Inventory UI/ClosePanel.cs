using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

    public void Onclick()
    {
        transform.parent.gameObject.SetActive(false);
        GameObject.Find("UI Manager").GetComponent<UiManager>().PanelClosed();
    }
}
