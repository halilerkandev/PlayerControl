using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject tank;
    private float time = 0f;
    private bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        TankInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 5f)
        {
            time = 0f;
            TankInstantiate();
        }
    }

    void TankInstantiate()
    {
        Vector3 position = tank.transform.position;
        isLeft = !isLeft;
        if (isLeft)
            position.x = 5;
        else
            position.x = -5;
        Debug.Log(position);
        Instantiate(tank, position, tank.transform.rotation);
    }
}
