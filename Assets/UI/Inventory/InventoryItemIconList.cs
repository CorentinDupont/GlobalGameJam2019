using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemIconList : MonoBehaviour
{

    public Inventory playerInventory;

    private RectTransform rectTransform;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update() {
        if(rectTransform.childCount != playerInventory.getItems().Count){
            refreshList();
        }
    }

    public void refreshList(){
        foreach (RectTransform child in rectTransform) {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in playerInventory.getItems()){
            GameObject go = new GameObject();
            Image image = go.AddComponent<Image>();
            image.sprite = item.icon;
            
            go.transform.SetParent(rectTransform);
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.localPosition = new Vector3(30, 30, 0);
            go.SetActive(true);
        }
    }
}
