using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private ComputerPuzzleManager computerPuzzleManager;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventoryItemSO item = inventorySO.itens.Find(x => x.Icon == eventData.pointerDrag.GetComponent<Image>().sprite);
            computerPuzzleManager.InsertCard(item);
        }
    }
}
