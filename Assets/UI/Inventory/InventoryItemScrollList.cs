using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScrollList : MonoBehaviour
{

    public Inventory playerInventory;

    [SerializeField]
    private RectTransform contentTransform;

    
    [SerializeField]
    private float itemTranslationSpeed;
    [SerializeField]
    private int actualSelectedItemID;
    [SerializeField]
    private float xDistanceBetweenItems;

    private float xCorrectAnchoredPosition;
    private bool scrollIsStopped = true;


    // Start is called before the first frame update
    void Start()
    {
        contentTransform = GetComponent<ScrollRect>().content;

        xCorrectAnchoredPosition = xDistanceBetweenItems * (-actualSelectedItemID);
        contentTransform.anchoredPosition = new Vector2(xCorrectAnchoredPosition, contentTransform.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Auto refresh content 
        if(contentTransform.childCount != playerInventory.getItems().Count){
            refreshList();
        }

        //Translation from selected item id
        if(contentTransform.anchoredPosition.x != xCorrectAnchoredPosition) {

            if (Mathf.Abs(contentTransform.anchoredPosition.x - xCorrectAnchoredPosition) < 0.1f){
                contentTransform.anchoredPosition = new Vector2(xCorrectAnchoredPosition, contentTransform.anchoredPosition.y);
                scrollIsStopped = true;
            }
            else {
                scrollIsStopped = false;
                float newPosX = Mathf.Lerp(contentTransform.anchoredPosition.x, xCorrectAnchoredPosition, Time.deltaTime * itemTranslationSpeed);
                contentTransform.anchoredPosition = new Vector2(newPosX, contentTransform.anchoredPosition.y);
            }
        }

        
    }

    public void nextItem() {
        xCorrectAnchoredPosition = contentTransform.anchoredPosition.x - xDistanceBetweenItems;
        actualSelectedItemID++;
    }

    public void previousItem(){
        xCorrectAnchoredPosition = contentTransform.anchoredPosition.x + xDistanceBetweenItems;
        actualSelectedItemID--;
    }

    public void refreshList(){
        foreach (RectTransform child in contentTransform) {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in playerInventory.getItems()){
            GameObject go = new GameObject();
            Image image = go.AddComponent<Image>();
            image.sprite = item.icon;
            
            go.transform.SetParent(contentTransform);
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.localPosition = new Vector3(100, 100, 0);
            go.SetActive(true);
        }
    }

    
}
