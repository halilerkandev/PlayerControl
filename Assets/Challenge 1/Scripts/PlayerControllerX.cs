using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 15f;
    private float rotationSpeed = 50f;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime * -verticalInput);

        if (transform.position.z > 300 ||
            transform.position.z < -90 ||
            transform.position.y > 120 ||
            transform.position.y < -40)
        {
            fixPosition();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        fixPosition();
    }

    void fixPosition()
    {
        transform.position = new(0, 20, -60);
        transform.rotation = new();
    }
}
