﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public OpenDoor op;
    public GameManager gm;

    public string nextRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(gm.nextRoom);
        if(other.name == "Player" && gm.nextRoom == nextRoom) {
            op.openDoor();
        }
    }
}
