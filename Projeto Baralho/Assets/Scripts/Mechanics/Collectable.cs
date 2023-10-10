using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : ClickableObjects
{
    public InventoryItemSO Item;
    public InventorySO inventory;
    public bool canInteract = true;

    public override void Interact()
    {
        if (canInteract)
        {
            inventory.AddItem(Item);
            Destroy(gameObject);
        }
    }

    public void GiveItem()
    {
        inventory.AddItem(Item);
    }

    public void SetInteraction()
    {
        canInteract = true;
    }
}
