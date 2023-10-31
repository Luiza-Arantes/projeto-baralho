using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GridLock : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;
    public List<GameObject> buttons;
    public List<bool> correctSequence;
    public List<bool> currentSequence;
    public UnityEvent onSolve;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (currentSequence[i])
            {
                buttons[i].GetComponent<Image>().sprite = onSprite;
            }
            else
            {
                buttons[i].GetComponent<Image>().sprite = offSprite;
            }
        }
    }

    public void CheckSolved()
    {
        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (correctSequence[i] != currentSequence[i])
            {
                return;
            }
        }

        OnSolve();
    }

    void OnSolve()
    {
        onSolve.Invoke();
    }

    public void ToggleButton(int index)
    {
        currentSequence[index] = !currentSequence[index];

        if (currentSequence[index])
        {
            buttons[index].GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            buttons[index].GetComponent<Image>().sprite = offSprite;
        }

        CheckSolved();
    }
}
