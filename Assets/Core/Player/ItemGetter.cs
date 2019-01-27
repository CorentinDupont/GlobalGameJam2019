using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ItemGetter : MonoBehaviour
{

    public int getterDistance;
    private Camera camera;
    private InventoryItem targetedInventoryItem;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {
         //Raycast to hit 
        RaycastHit hitInfo;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, getterDistance)){

            //if hit object is type draggable
            if (hitInfo.transform.gameObject.GetComponent<InventoryItem>() && targetedInventoryItem == null) {
                InventoryItem inventoryItem = hitInfo.transform.gameObject.GetComponent<InventoryItem>();                
                inventoryItem.targetObject();
                targetedInventoryItem = inventoryItem;
            }        
        }else if(targetedInventoryItem != null){
            targetedInventoryItem.unTargetObject();
            targetedInventoryItem = null;

        } 

        //Click to add item in inventory
        if (Input.GetMouseButtonDown(0) && targetedInventoryItem != null){
            GetComponent<Inventory>().addItem(targetedInventoryItem);
            Destroy(targetedInventoryItem.gameObject);
             GetComponent<Inventory>().logInventoryItems();
        }
    }
}
