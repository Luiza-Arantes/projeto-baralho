using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private ComputerPuzzleManager computerPuzzleManager;
    [SerializeField] private bool discReader;
    [SerializeField] private UnityEvent dropEvent;
    [SerializeField] private InventoryItemSO neededItem;

    void Awake()
    {
        if (dropEvent == null)
            dropEvent = new UnityEvent();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventoryItemSO item = inventorySO.itens.Find(x => x.Icon == eventData.pointerDrag.GetComponent<Image>().sprite);

            if (neededItem != null && item == neededItem)
            {
                dropEvent?.Invoke();
                inventorySO.RemoveItem(item);
                return;
            }

            if (item.Name == "CD" && discReader)
            {
                computerPuzzleManager.InsertDisc(item);
            }
            else
            {
                computerPuzzleManager.InsertCard(item);
            }
        }
    }
}
