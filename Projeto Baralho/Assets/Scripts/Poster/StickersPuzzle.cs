using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StickersPuzzle : MonoBehaviour {

    public List<Sticker> solutionStickers;
    public List<int> solutionIndexes;
    public UnityEvent onSolve;
    Dictionary<Sticker,int> stickerPositions;

    private void Awake() {
        stickerPositions = new Dictionary<Sticker, int>();
    }
    public void SetSticker(Sticker sticker, int index)
    {
        stickerPositions[sticker] = index;
        CheckSolved();
    }

    public void RemoveSticker(Sticker sticker)
    {
        stickerPositions.Remove(sticker);
    }

    public void CheckSolved()
    {
        if(solutionStickers.Count != solutionIndexes.Count)
        {
            Debug.Log("ERRO! solução impossível");
        }
        for (int i=0;i<solutionStickers.Count;i++)
        {
            if(!stickerPositions.ContainsKey(solutionStickers[i]))
            {
                return;
            }
            if(stickerPositions[solutionStickers[i]] != solutionIndexes[i])
            {
                return;
            }
        }
        onSolve.Invoke();
        Debug.Log("SOLVE!");
    }


}