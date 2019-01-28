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

    private Color initialMaterialColor;
    public Material targetMaterial;

    [SerializeField]
    private Renderer renderer;

    public bool canBeAddedToInventory;

    // Start is called before the first frame update
    void Start()
    {
        initialMaterialColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void targetObject(){
        renderer.material.color = targetMaterial.color;
    }

    public void unTargetObject(){
        renderer.material.color = initialMaterialColor;
    }
}
