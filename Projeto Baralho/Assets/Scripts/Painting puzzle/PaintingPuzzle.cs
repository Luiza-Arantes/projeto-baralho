using UnityEngine;
using UnityEngine.UI;

public class PaintingPuzzle : MonoBehaviour
{
    public PaintingPart[] parts;
    public Pencil[] pencils;
    public Pencil pencil;
    public GameObject entrance;
    // Start is called before the first frame update
    void Start()
    {   for (int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
        }
     }

    // Update is called once per frame
    void Update()
    {
        if (isComplete()) { 
              entrance.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0) && pencil!=null)
        {
            for(int i = 0;i<parts.Length;i++)
            {
                if (IsPencilOverPart(parts[i]) && !parts[i].isPainted)
                {
                    Paint(parts[i]);
                }
            }
             
        }
        for (int i = 0; i < pencils.Length; i++)
        {
            if (pencils[i].GetComponent<DragDrop>().isBeingDragged)
            {
                pencil = pencils[i];
                break;
            }
            else
            {
                pencil = null;
            }
        }
    }

    private bool isComplete()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (!parts[i].isPainted)
            {
                return false;
            }
         }
        return true;
    }
    public void Paint(PaintingPart part)
    {
        
        {
            part.GetComponent<Image>().color = pencil.color;
            if (part.rightPencil == pencil)
            {
                part.isPainted = true;
            }
        }
    }

    bool IsPencilOverPart(PaintingPart part)
    {
        if (part.isMouseOver)
        {
            return true;
        }

        return false;
    }

}
