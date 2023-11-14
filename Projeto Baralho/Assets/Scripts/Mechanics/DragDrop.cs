using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform parentTransform;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public bool isBeingDragged;
    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        isBeingDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        isBeingDragged = false;

        transform.position = parentTransform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void ChangeParent(RectTransform transform)
    {
        parentTransform = transform;
        canvasGroup.blocksRaycasts = true;
        isBeingDragged = false;
        this.transform.position = parentTransform.position;
    }
}
