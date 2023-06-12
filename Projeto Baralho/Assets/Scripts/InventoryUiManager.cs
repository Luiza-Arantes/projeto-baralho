using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiManager : MonoBehaviour
{
    public InventorySO inventory;
    public List<InventoryBoxUi> inventoryBoxes = new List<InventoryBoxUi>();


    private void OnEnable()
    {
        inventory.itemEvent.AddListener(UpdateUi);
    }

    private void OnDisable()
    {
        inventory.itemEvent.RemoveListener(UpdateUi);
    }

    private void UpdateUi()
    {
        for (int i = 0; i < inventory.itens.Count; i++)
        {
            Debug.Log(inventory.itens[i].Name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
