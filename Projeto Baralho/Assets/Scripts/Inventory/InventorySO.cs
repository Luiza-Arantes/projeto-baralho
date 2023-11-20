using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName="Inventory",menuName="ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventoryItemSO> itens = new List<InventoryItemSO>();

    public UnityEvent itemEvent;

    private void OnEnable()
    {
        if (itemEvent == null)
        {
            itemEvent = new UnityEvent();
        }

        itens.Clear();
    }

    public void AddItem(InventoryItemSO item)
    {
        itens.Add(item);

        itemEvent?.Invoke();

        AudioManager.Instance.PlaySound("GrabItem", Vector3.zero);
    }

    public void RemoveItem(InventoryItemSO item)
    {
        itens.Remove(item);

        itemEvent?.Invoke();
    }

}

