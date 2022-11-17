using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCard : MonoBehaviour
{
    [SerializeField] GameObject card;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        if (card.activeSelf)
        {
            card.SetActive(false);
        }
        Debug.Log("testing 1 2 3");
    }
}
