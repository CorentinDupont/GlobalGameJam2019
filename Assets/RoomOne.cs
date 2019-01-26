using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{

    public GameManager gameManager;
    // All the enigma validation methods are on this class

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool canOpenDoorFromInside() {
        return gameManager.roomOne;
    }
}
