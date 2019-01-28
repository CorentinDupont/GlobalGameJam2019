using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    RectTransform inventoryMenu;
    [SerializeField]
    RectTransform itemPreviewPanel;

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
            }else if(itemPreviewPanel.gameObject.activeSelf){
                closePreviewItemPanel();
            }else
            {
                openInventoryMenu();
            }
        }
    }

    private void openInventoryMenu(){
        inventoryMenu.gameObject.SetActive(true);
        Debug.Log("OPEN");
    }

    private void closeInventoryMenu(){
        inventoryMenu.gameObject.SetActive(false);
        Debug.Log("CLOSE");

    }

    public void previewItem(InventoryItem item){
        itemPreviewPanel.Find("Image").GetComponent<Image>().sprite = item.image;
        openPreviewItemPanel();
    }

    public void openPreviewItemPanel(){
        itemPreviewPanel.gameObject.SetActive(true);
    }

    public void closePreviewItemPanel(){
        itemPreviewPanel.gameObject.SetActive(false);
    }
}
