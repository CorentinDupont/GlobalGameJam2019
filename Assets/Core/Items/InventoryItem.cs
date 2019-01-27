using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;

    //icon shown in the small bottom right list
    public Sprite icon;

    //image shown in inventory menu
    public Sprite image;

    private Material initialMaterial;
    public Material targetMaterial;

    // Start is called before the first frame update
    void Start()
    {
        initialMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void targetObject(){
        GetComponent<Renderer>().material = targetMaterial;
    }

    public void unTargetObject(){
        GetComponent<Renderer>().material = initialMaterial;
    }
}
