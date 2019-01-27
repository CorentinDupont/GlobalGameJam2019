using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateCloser : MonoBehaviour
{    
    public OpenDoor op;

    public GameManager gm;

    public string actualRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(other.name == "Player" && actualRoom == "roomOne") {
            op.closeDoor();
            gm.nextRoom = "roomTwo";
        }
        if(other.name == "Player" && actualRoom == "roomTwo") {
            op.closeDoor();
            gm.nextRoom = "roomThree";
        }
    }
}
