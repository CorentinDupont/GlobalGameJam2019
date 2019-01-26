// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)
 
using UnityEngine;
using System.Collections;
 
// Makes objects float up & down while gently spinning.
public class Rotater : MonoBehaviour {
    // User Inputs
    public float degreesPerSecond = 10.0f;
    public Rigidbody rb;
 
    // Position Storage Variables
    Vector3 posOffset = new Vector3 ();
    // Use this for initialization
    void Start () {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(1,1,1));
    }
     
    // Update is called once per frame
    void Update () {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
    }
}