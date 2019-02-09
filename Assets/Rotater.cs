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

    private GameManager gm;
 
    // Position Storage Variables
    Vector3 posOffset = new Vector3 ();
    // Use this for initialization
    void Start () {
        // Store the starting position & rotation of the object
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        posOffset = transform.position;
        rb.AddForce(new Vector3(Random.Range(Random.Range(-2f, -1f), Random.Range(1f, 2f)), Random.Range(Random.Range(-2f, -1f), Random.Range(1f, 2f)), Random.Range(Random.Range(-2f, -1f), Random.Range(1f, 2f))));
    }
     
    // Update is called once per frame
    void Update () {
        // Spin object around Y-Axis
        if(gm.enigmaOne)
            rb.useGravity = true;
        else
            transform.Rotate(new Vector3(Time.deltaTime * degreesPerSecond , Time.deltaTime * degreesPerSecond, Time.deltaTime * degreesPerSecond), Space.World);
    }

    private void OnCollisionEnter(Collision other) {
        if(!gm.enigmaOne)
            rb.AddForce(new Vector3(Random.Range(Random.Range(-2f, -1f), Random.Range(1f, 2f)), Random.Range(Random.Range(-2f, -1f), Random.Range(1f, 2f)), Random.Range(Random.Range(-2f, -1f), Random.Range(1f, 2f))));
    }
}