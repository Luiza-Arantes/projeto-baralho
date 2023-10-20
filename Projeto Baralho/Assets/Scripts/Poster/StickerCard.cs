using UnityEngine;
using UnityEngine.EventSystems;

public class StickerCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<Sticker>(out var sticker))
        {
            if (!eventData.pointerDrag.TryGetComponent<DragDrop>(out var drag))
            {
                Debug.Log("Error! drag faltando");
            }

            drag.ChangeParent(drag.transform.parent.transform as RectTransform);

        }
        sticker.puzzle.RemoveSticker(sticker);
    }
}