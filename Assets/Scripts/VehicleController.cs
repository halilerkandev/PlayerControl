using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private readonly float speed = 10f;
    private readonly float friction = 3f;
    private readonly float turnFriction = 3f;
    private Vector3 velocity = Vector3.zero;
    private float angularVelocity = 0f;

    public GameObject innerCamera;
    public GameObject outerCamera;
    private bool toggle = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    KeyCode Right;
    KeyCode Left;
    KeyCode Up;
    KeyCode Down;
    KeyCode Toggle;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        (KeyCode Right, KeyCode Left, KeyCode Up, KeyCode Down, KeyCode Toggle) = GetKeysByTag(gameObject.tag);
        this.Right = Right;
        this.Left = Left;
        this.Up = Up;
        this.Down = Down;
        this.Toggle = Toggle;
        innerCamera.SetActive(false);
        outerCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
        HandleVelocity();
        HandleReposition();
    }

    void HandleCamera()
    {
        if (Input.anyKeyDown && Input.GetKey(Toggle))
        {
            toggle = !toggle;
            innerCamera.SetActive(toggle);
            outerCamera.SetActive(!toggle);
        }
    }

    void HandleVelocity()
    {
        float newVelocity = 0f;
        float newAngularVelocity = 0f;
        float additional = velocity.z >= 0 ? 8 : -8;

        if (Input.GetKey(Up))
            newVelocity += speed;

        if (Input.GetKey(Down))
            newVelocity -= speed;

        if (Input.GetKey(Left))
            newAngularVelocity -= velocity.z * 3 + additional;

        if (Input.GetKey(Right))
            newAngularVelocity += velocity.z * 3 + additional;

        velocity.z = Mathf.Lerp(velocity.z, newVelocity, friction * Time.deltaTime);
        if (velocity.z < -1 || velocity.z > 1)
            angularVelocity = Mathf.Lerp(angularVelocity, newAngularVelocity, turnFriction * Time.deltaTime);
        else
            angularVelocity = Mathf.Lerp(angularVelocity, 0f, turnFriction * Time.deltaTime);

        transform.Rotate(Vector3.up, angularVelocity * Time.deltaTime);
        transform.Translate(velocity * Time.deltaTime);
    }

    void HandleReposition()
    {
        if (transform.position.z > 185 ||
            transform.position.z < -15 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            transform.position.y < -50)
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }

    (KeyCode Right, KeyCode Left, KeyCode Up, KeyCode Down, KeyCode Toggle) GetKeysByTag(string tag)
    {
        return tag == "Vehicle1" ? (KeyCode.D, KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.E) :
            (KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.L);
    }
}
