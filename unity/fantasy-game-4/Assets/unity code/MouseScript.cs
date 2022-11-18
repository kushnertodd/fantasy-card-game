using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    bool tapped = false;
    private void Start()
    {
        Debug.Log("MouseScript starting!");
    }
    public void OnMouseDown()
    {
        if (!tapped)
        {
            tapped = true;
            Vector3 rotationToAdd = new Vector3(0, 0, 90);
            transform.Rotate(rotationToAdd);
            LoadScript.setManaChanged(true);
            Debug.Log("rotated untapped mousescript!");
        }
        else
        {
            tapped = false;
            Vector3 rotationToAdd = new Vector3(0, 0, -90);
            transform.Rotate(rotationToAdd);
            Debug.Log("rotated tapped mousescript!");
        }
    }
}
