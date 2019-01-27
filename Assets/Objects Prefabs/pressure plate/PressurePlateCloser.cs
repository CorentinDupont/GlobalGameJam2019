using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateCloser : MonoBehaviour
{    
    public OpenDoor op;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            op.closeDoor();
            gm.nextRoom = "roomTwo";
        }
    }
}
