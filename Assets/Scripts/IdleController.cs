using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 10f * Time.deltaTime);

        if (transform.position.z > 185 ||
            transform.position.z < -15 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
}
