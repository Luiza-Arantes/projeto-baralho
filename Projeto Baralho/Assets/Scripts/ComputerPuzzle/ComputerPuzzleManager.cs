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
    public bool insertedDisc = false;
    [SerializeField] private GameObject windowsBg;
    [SerializeField] private GameObject window;

    [SerializeField] private List<Toggle> toggles = new List<Toggle>();

    // Start is called before the first frame update
    void OnEnable()
    {
        currentOrder.Clear();

        if (completed)
        {
            
            windowsBg.SetActive(true);
    
            if (insertedDisc)
            {
                window.SetActive(true);
            }
        }
    }

    public void InsertCard(InventoryItemSO card)
    {
        if (!card.Name.Contains("Glasses") && !card.Name.Contains("Shirt") && !card.Name.Contains("Pants") && !card.Name.Contains("Shoes"))
            return;

        if (completed)
            return;

        currentOrder.Add(card);
        inventory.RemoveItem(card);

         AudioManager.Instance.PlaySound("CardSwipe", Vector3.zero);

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
        Progression.IncrementCounter("Reflexo");
        windowsBg.SetActive(true);
        List<InventoryItemSO> itensToRemove = new List<InventoryItemSO>();

        for (int i = 0; i < inventory.itens.Count; i++)
        {
            if (inventory.itens[i].Name.Contains("Glasses") || inventory.itens[i].Name.Contains("Shirt") || inventory.itens[i].Name.Contains("Pants") || inventory.itens[i].Name.Contains("Shoes"))
            {
                itensToRemove.Add(inventory.itens[i]);
            }
        }

        foreach (InventoryItemSO item in itensToRemove)
        {
            inventory.RemoveItem(item);
        }
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
    }

    public void InsertDisc(InventoryItemSO item)
    {
        if (!insertedDisc)
        {
            window.SetActive(true);
            inventory.RemoveItem(item);
            insertedDisc = true;
        }
    }

    public bool GetCompleted()
    {
        return completed;
    }
}
