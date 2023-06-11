using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : ClickableObjects
{
    public string ItemName;
    public InventorySO inventory;

    public override void Interact()
    {
        inventory.AddItem(ItemName);
        Destroy(gameObject);
    }
}
