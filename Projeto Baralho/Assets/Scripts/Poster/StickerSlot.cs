using UnityEngine;
using UnityEngine.EventSystems;

public class StickerSlot : MonoBehaviour, IDropHandler
{
    public int index;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<Sticker>(out var sticker))
        {
            if(!eventData.pointerDrag.TryGetComponent<DragDrop>(out var drag))
            {
                Debug.Log("Error! drag faltando");
            }
            drag.ChangeParent(GetComponent<RectTransform>());
        }
        sticker.puzzle.SetSticker(sticker,index);
    }
}