using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SymbolLock : MonoBehaviour
{
    public List<Sprite> allSprites;
    public List<Sprite> correctSequence;
    public List<Image> images;

    public UnityEvent onSolve;

    public void CheckSolved()
    {
        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (correctSequence[i] != images[i].sprite)
            {
                return;
            }
        }
        foreach (var image in images)
        {
            foreach (Transform child in image.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        Invoke( nameof(OnSolve), 1f ); 
    }

    void OnSolve()
    {
        onSolve.Invoke();
    }

    public void MoveUp(int imageIndex)
    {
        var curr = allSprites.FindIndex((sprite) => sprite == images[imageIndex].sprite);
        var newIndex = (curr + 1) % allSprites.Count;
        images[imageIndex].sprite = allSprites[newIndex];
        CheckSolved();

    }
    public void MoveDown(int imageIndex)
    {
        var curr = allSprites.FindIndex((sprite) => sprite == images[imageIndex].sprite);
        var newIndex = curr - 1;
        if (newIndex < 0)
        {
            newIndex = allSprites.Count - 1;
        }
        images[imageIndex].sprite = allSprites[newIndex];
        CheckSolved();
    }

}
