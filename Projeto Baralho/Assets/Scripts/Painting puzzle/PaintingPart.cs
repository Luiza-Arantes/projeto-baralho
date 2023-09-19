using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;

public class PaintingPart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isMouseOver = false;

    public bool isPainted;
    public Pencil rightPencil;
    [HideInInspector]
    public RectTransform rectTransform;
     // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Mouse entered the image
        isMouseOver = true;
        Debug.Log("Mouse entered the image.");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Mouse exited the image
        isMouseOver = false;
        Debug.Log("Mouse exited the image.");
    }

}
