using UnityEngine;
using UnityEngine.UI;

public class LightsOutCell : MonoBehaviour
{
    public bool isOn;
    public int index;
    public Image image;

    void UpdateSprite()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        if (isOn)
        {
            image.color = Color.clear;
        }
        else
        {
            image.color = Color.black;
        }
    }
    private void Start()
    {
        UpdateSprite();
    }
    public void Flip()
    {
        isOn = !isOn;
        UpdateSprite();
    }
    public void OnClick()
    {
        LightsOut.instance.OnCellClicked(index);
        
        AudioManager.Instance.PlaySound("LightsOutClick", Vector3.zero);
    }
}