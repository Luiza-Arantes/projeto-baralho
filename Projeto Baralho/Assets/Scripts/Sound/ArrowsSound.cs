using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsSound : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.Instance.PlaySound("IngameClick", Vector3.zero);
    }

    public void RevealPainting()
    {
        AudioManager.Instance.PlaySound("PaintingReveal", Vector3.zero);
    }
}
