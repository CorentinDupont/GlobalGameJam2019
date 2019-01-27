using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    RectTransform inventoryMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check input to open inventory menu
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(inventoryMenu.gameObject.activeSelf){
                closeInventoryMenu();
            }else{
                openInventoryMenu();
            }
        }
    }

    private void openInventoryMenu(){
        inventoryMenu.gameObject.SetActive(true);
    }

    private void closeInventoryMenu(){
        inventoryMenu.gameObject.SetActive(false);
    }
}
