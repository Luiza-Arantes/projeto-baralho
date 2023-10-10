using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInteractable : ClickableObjects
{
    public GameObject popupCanvas;
    public bool canInteract = true;

    public override void Interact()
    {
        if (canInteract)
            popupCanvas.SetActive(true);
    }

    public void SetInteraction()
    {
        canInteract = true;
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
