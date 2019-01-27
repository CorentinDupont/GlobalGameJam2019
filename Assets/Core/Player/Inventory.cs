using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> inventory = new List<InventoryItem>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<InventoryItem> getItems(){
        return inventory;
    }

    public void addItem(InventoryItem item){
        inventory.Add(item);

        Debug.Log(getItems());
        logInventoryItems();
    }

    public void logInventoryItems(){
        foreach (var item in inventory)
        {
            Debug.Log(item.name);
        }
    }
}
