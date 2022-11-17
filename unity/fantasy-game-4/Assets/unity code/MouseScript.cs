using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("MouseScript starting!");
    }
    public void OnMouseDown()
    {
        //GameObject card = GameObject.Find("GameObject");
        //GameObject card = GetComponent<GameObject>();
        Vector3 rotationToAdd = new Vector3(0, 0, 90);
        transform.Rotate(rotationToAdd);
        Debug.Log("rotated mousescript!");
    }
}
