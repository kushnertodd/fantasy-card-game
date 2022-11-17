using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.Find("GameObject");
        Sprite image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        if (image != null)
        {
            GameObject gameObject = card;
            gameObject.AddComponent<SpriteRenderer>();
            //gameObject.AddComponent(System.Type.GetType("MouseScript"));
            gameObject.AddComponent<BoxCollider>();
            gameObject.GetComponent<SpriteRenderer>().sprite = image;
            Debug.Log("GameObject LoadScript loaded!");
        }
        else
            Debug.Log("uh-oh, 'basic_land_edit.png' not found!");
    }
    public void OnMouseDown()
    {
        if (card.activeSelf)
        {
            card.SetActive(false);
        }
        Debug.Log("card inactive");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
