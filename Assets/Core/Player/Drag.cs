using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public int dragDistance;
    private Camera camera;
    private Draggable targetedDraggableObject;
    private Draggable draggingObject;
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
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, dragDistance)){

            //if hit object is type draggable
            if (hitInfo.transform.gameObject.GetComponent<Draggable>()) {
                Draggable hitDraggableObject = hitInfo.transform.gameObject.GetComponent<Draggable>();
                //if this object can be draggable 
                if(hitDraggableObject.isDraggable){
                    hitDraggableObject.targetObject();
                    targetedDraggableObject = hitDraggableObject;
                }                
            }

        }else if(targetedDraggableObject != null){
            targetedDraggableObject.unTargetObject();
            targetedDraggableObject = null;
        }

        //Click to make an action on a draggable object
        if (Input.GetMouseButtonDown(0)){
            if(targetedDraggableObject != null && draggingObject == null){
                //grab the object
                targetedDraggableObject.gameObject.transform.parent = this.transform;
                targetedDraggableObject.gameObject.transform.localPosition = GameObject.Find("DraggableObjectSocket").transform.localPosition;
                targetedDraggableObject.isDraggable = false;
                targetedDraggableObject.GetComponent<Rigidbody>().isKinematic = true;
                targetedDraggableObject.unTargetObject();
                draggingObject = targetedDraggableObject;
                targetedDraggableObject = null;
            }else if(targetedDraggableObject == null && draggingObject != null){
                //leave the object
                draggingObject.gameObject.transform.parent = draggingObject.initialParent;
                draggingObject.isDraggable = true;
                draggingObject.GetComponent<Rigidbody>().isKinematic = false;
                draggingObject = null;

            }
        }
    }

    // void GrabObject(Draggable object){
        
    // }
}
