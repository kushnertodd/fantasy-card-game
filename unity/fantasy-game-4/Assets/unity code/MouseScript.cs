using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    GameObject card;

    public void OnMouseDown1()
    {
        card = GameObject.Find("GameObject");
        if (card.activeSelf)
        {
            card.SetActive(false);
        }
        Debug.Log("testing 1 2 3");
    }
}
