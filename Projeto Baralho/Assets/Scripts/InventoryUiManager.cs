using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiManager : MonoBehaviour
{
    public InventorySO inventory;

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
        Debug.Log("Funciona");
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
