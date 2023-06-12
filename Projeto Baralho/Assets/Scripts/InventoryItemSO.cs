using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/InventoryItem")]
public class InventoryItemSO : ScriptableObject
{
    public string Name;

    public Sprite Icon;
}
