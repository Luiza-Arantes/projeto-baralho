using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName="Inventory",menuName="ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<string> itens = new List<string>();

    public UnityEvent itemEvent;

    private void OnEnable()
    {
        if (itemEvent == null)
        {
            itemEvent = new UnityEvent();
        }

        itens.Clear();
    }

    public void AddItem(string item)
    {
        itens.Add(item);

        itemEvent?.Invoke();
    }

    public void RemoveItem(string item)
    {
        itens.Remove(item);

        itemEvent?.Invoke();
    }

}

