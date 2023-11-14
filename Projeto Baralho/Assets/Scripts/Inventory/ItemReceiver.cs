using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemReceiver : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private string itemName;
    [SerializeField] private UnityEvent onReceive;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventoryItemSO item = inventorySO.itens.Find(x => x.Icon == eventData.pointerDrag.GetComponent<Image>().sprite);
            if (item == null)
            {
                return;
            }
            if (item.Name == itemName)
            {
                onReceive.Invoke();
                inventorySO.RemoveItem(item);
            }
        }
    }
}
