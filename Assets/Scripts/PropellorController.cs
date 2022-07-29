using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorController : MonoBehaviour
{
    public GameObject plane;
    private float turnSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed);
    }
}
