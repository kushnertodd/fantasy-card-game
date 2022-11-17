using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    Experiment2 experiment = new Experiment2();
    // Start is called before the first frame update
    void Start()
    {
        //experiment = new Experiment1();
        experiment.Start();
    }
    public void OnMouseDown()
    {
        experiment.OnMouseDown();
    }

    // Update is called once per frame
    void Update()
    {
        experiment.Update();
    }
}

// just prints message on mouse down
public class Experiment1
{
    GameObject card;
    // Start is called before the first frame update
    public void Start()
    {
        card = GameObject.Find("GameObject");
        // var images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        Sprite image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        if (image != null)
        {
            card.AddComponent<SpriteRenderer>();
            //gameObject.AddComponent(System.Type.GetType("MouseScript"));
            card.AddComponent<BoxCollider>();
            card.GetComponent<SpriteRenderer>().sprite = image;
            Debug.Log("GameObject LoadScript loaded!");
        }
        else
            Debug.Log("uh-oh, 'basic_land_edit.png' not found!");
    }
    public void OnMouseDown()
    {
        Debug.Log("mouse down");
    }

    // Update is called once per frame
    public void Update()
    {

    }
}

// makes card inactive on mouse down
public class Experiment2
{
    GameObject card;
    // Start is called before the first frame update
    public void Start()
    {
        card = GameObject.Find("GameObject");
        // var images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        Sprite image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        if (image != null)
        {
            card.AddComponent<SpriteRenderer>();
            //gameObject.AddComponent(System.Type.GetType("MouseScript"));
            card.AddComponent<BoxCollider>();
            card.GetComponent<SpriteRenderer>().sprite = image;
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
            Debug.Log("card inactive");
        }
        else
        {
            card.SetActive(true);
            Debug.Log("card active");
        }
    }

    // Update is called once per frame
    public void Update()
    {

    }
}