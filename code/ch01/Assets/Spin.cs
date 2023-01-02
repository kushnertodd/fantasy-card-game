using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speedX = 3.0f;
    public float speedY = 3.0f;
    public float speedZ = 3.0f;
    public bool world = false;

    // Update is called once per frame
    void Update()
    {
        if (world)
            transform.Rotate(speedX, speedY, speedZ, Space.World);
        else
            transform.Rotate(speedX, speedY, speedZ, Space.Self);
    }
}
