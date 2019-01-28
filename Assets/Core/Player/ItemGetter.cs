using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ItemGetter : MonoBehaviour
{

    public float getterDistance;
    public float radiusDistance;

    public LayerMask layerMask;
    private Camera camera;

 [SerializeField]
    private GameObject head;
    [SerializeField]
    private UIManager uiManager;

    private InventoryItem targetedInventoryItem;

    private GameManager GM;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        GM = FindObjectOfType<GameManager>();
               
    }

    // Update is called once per frame
    void Update()
    {
         //Raycast to hit 
        RaycastHit hitInfo;
        if(Physics.SphereCast(head.transform.position, radiusDistance, head.transform.forward, out hitInfo, getterDistance, layerMask)){
            Debug.Log(hitInfo.transform.gameObject.name);
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

        //Click space to add item in inventory
        if (Input.GetKeyDown(KeyCode.Space) && targetedInventoryItem != null){
            if(targetedInventoryItem.canBeAddedToInventory){
                //add item to inventory
                GetComponent<Inventory>().addItem(targetedInventoryItem);
                Destroy(targetedInventoryItem.gameObject);
                GetComponent<Inventory>().logInventoryItems();
                
                if(GM.nextRoom == "roomTwo" && GM.roomOne == false){
                    FindObjectOfType<RoomOne>().launchActionFor(targetedInventoryItem.gameObject);
                }
            }else{
                //preview item
                uiManager.previewItem(targetedInventoryItem);
            }
            
        }
    }
}
