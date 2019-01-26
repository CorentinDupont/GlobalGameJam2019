using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController controller;
    Camera camera;
    public Vector3 moveDirection = new Vector3(0, 0, 0);
    public int moveSpeed;
    public int gravity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
            
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // transform.eulerAngles = transform.eulerAngles * new Vector3(0, h, 0);

        movement += transform.forward * v * moveSpeed * Time.deltaTime;
        movement += transform.right * h * moveSpeed * Time.deltaTime;

        movement.y = movement.y - (gravity * Time.deltaTime);

        controller.Move(movement * Time.deltaTime);

        // transform.Rotate(new Vector3(0, h, 0));


        Vector3 cameraRotation = camera.transform.eulerAngles;
        Vector3 playerRotation = new Vector3(0, cameraRotation.y, cameraRotation.z);
        transform.eulerAngles = camera.transform.eulerAngles;
        

    }
}
