using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Draggable : MonoBehaviour
{

    private Material initialMaterial;
    public Material targetMaterial;
    public Transform initialParent;

    public bool isDraggable = true;

    [SerializeField]
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        //save inital material
        initialMaterial = renderer.material;
        initialParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void targetObject(){
        renderer.material = targetMaterial;
    }

    public void unTargetObject(){
        renderer.material = initialMaterial;
    }
}
