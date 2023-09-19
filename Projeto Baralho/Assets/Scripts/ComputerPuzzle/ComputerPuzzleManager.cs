using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerPuzzleManager : MonoBehaviour
{
    [SerializeField] private InventorySO inventory;
    [SerializeField] private List<InventoryItemSO> rightOrder = new List<InventoryItemSO>();
    [SerializeField] private List<InventoryItemSO> currentOrder = new List<InventoryItemSO>();
    [SerializeField] private bool completed = false;

    [SerializeField] private List<Toggle> toggles = new List<Toggle>();

    // Start is called before the first frame update
    void OnEnable()
    {
        currentOrder.Clear();
    }

    public void InsertCard(InventoryItemSO card)
    {
        currentOrder.Add(card);
        inventory.RemoveItem(card);

        if (card.Name.Contains("Glasses"))
        {
            toggles[0].isOn = true;
        }
        else if (card.Name.Contains("Shirt"))
        {
            toggles[1].isOn = true;
        }
        else if (card.Name.Contains("Pants"))
        {
            toggles[2].isOn = true;
        }
        else if (card.Name.Contains("Shoes"))
        {
            toggles[3].isOn = true;
        }

        if (currentOrder.Count >= 4)
        {
            CheckAnswer();
        }
    }

    private void CheckAnswer()
    {
        for (int i = 0; i < rightOrder.Count; i++)
        {
            if (rightOrder[i] != currentOrder[i])
            {
                ResetPuzzle();
                return;
            }
        }

        completed = true;
    }

    private void ResetPuzzle()
    {
        for (int i = 0; i < currentOrder.Count; i++)
        {
            inventory.AddItem(currentOrder[i]);
        }

        for (int i = 0; i < toggles.Count; i++)
        {
            toggles[i].isOn = false;
        }

        currentOrder.Clear();
    }

    public void ClosePopup()
    {
        if (!completed)
        {
            ResetPuzzle();
        }

        gameObject.SetActive(false);

        //acho que aqui eu escrevo que abre o popup do pc desbloqueado
    }
}
