using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Global room state
    public bool roomOne = false;
    public bool roomTwo = false;
    
    // Enigma state
    public bool enigmaOne = false;
    public bool enigmaTwo = false;
    public bool enigmaThree = false;

    // Next room to spawn
    public string nextRoom = "roomOne";

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void validEnigmaOne() {
        enigmaOne = true;
        if(enigmaOne)
            roomOne = true;
    }

    public void validEnigmaTwo() {
        enigmaTwo = true;
        if(enigmaTwo && enigmaThree)
            roomTwo = true;
    }

    public void validEnigmaThree() {
        enigmaThree = true;
        if(enigmaTwo && enigmaThree)
            roomTwo = true;
    }

    public MonoBehaviour getCurrentRoom(){
        
        return null;
    }
}
