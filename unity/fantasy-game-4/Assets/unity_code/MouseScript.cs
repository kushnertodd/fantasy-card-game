using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private bool tapped = false;
    private bool played = false;
    public static bool rotating = false;
    public static float total_rotation = 0;
    public static float current_rotation = 0;
    public static float rotation_rate;
    public static float net_rotation_rate = 0.5f;
    public static Transform rotate_transform;
    private void Start()
    {
        Debug.Log("MouseScript starting!");
    }
    public void OnMouseDown()
    {
        if (!played)
        {
            Vector3 pos = transform.position;
            pos.y = pos.y + 5;
            transform.position = pos;
            played = true;
        }else
        if (!rotating) { 
        rotate_transform = transform;
        if (!tapped)
        {
            tapped = true;
            rotation_rate = net_rotation_rate;
            current_rotation = 0;
            total_rotation = 90;
            LoadScript.setManaChanged(true);
            Debug.Log("rotated untapped mousescript!");
        }
        else
        {
            tapped = false;
            rotation_rate = -net_rotation_rate;
            current_rotation = 0;
            total_rotation = -90;
            Debug.Log("rotated tapped mousescript!");
        }
        rotating = true;
        }
    }
}
