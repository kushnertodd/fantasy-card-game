using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class cubespin : MonoBehaviour
{
    public float speed_roll = 3f;
    public float speed_yaw = 3f;
    public float speed_pitch = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed_roll, speed_yaw, speed_pitch);
    }
}
