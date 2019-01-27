using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    private bool doorIsOpening = false;
    private bool doorIsClosing = false;

    private float doorSpeed = 70f;
    public GameObject doorRotater;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorIsOpening)
            doorRotater.transform.Rotate(new Vector3(0f, Time.deltaTime * doorSpeed, 0f), Space.World);
        else if(doorIsClosing)
            doorRotater.transform.Rotate(new Vector3(0f, Time.deltaTime * -doorSpeed, 0f), Space.World);
        else
            doorRotater.transform.Rotate(new Vector3(0, 0, 0));
    }

    public void openDoor() {
        doorIsOpening = true;
    }

    public void closeDoor() {
        doorIsClosing = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "doorOpeningTrigger")
            doorIsOpening = false;

        if(other.name == "doorClosingTrigger")
            doorIsClosing = false;
    }
}
