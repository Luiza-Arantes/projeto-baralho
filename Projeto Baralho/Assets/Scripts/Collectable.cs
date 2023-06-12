using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : ClickableObjects
{
    public InventoryItemSO Item;
    public InventorySO inventory;

    public override void Interact()
    {
        inventory.AddItem(Item);
        Destroy(gameObject);
    }
}
