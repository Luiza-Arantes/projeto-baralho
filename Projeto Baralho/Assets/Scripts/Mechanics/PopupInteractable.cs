using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInteractable : ClickableObjects
{
    public GameObject popupCanvas;
    public GameObject closeCanvas;

    public override void Interact()
    {
        popupCanvas.SetActive(true);
        closeCanvas.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
