using fantasy_card_game_lib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadScript : MonoBehaviour
{
    Experiment4 experiment = new Experiment4();
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

// randomly select card from Resources and makes card inactive on mouse down
public class Experiment3
{
    GameObject card;
    private int _id;
    public int Id { get { return _id; } }
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        card.GetComponent<SpriteRenderer>().sprite = image;
    }
    // Start is called before the first frame update
    public void Start()
    {
        card = GameObject.Find("GameObject");
        card.AddComponent<SpriteRenderer>();
        //gameObject.AddComponent(System.Type.GetType("MouseScript"));
        card.AddComponent<BoxCollider>();
        //Sprite[] images = (Sprite[])Resources.LoadAll("Sprites");
        Sprite[] images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        if (images != null)
        {
            int id = Random.Range(0, images.Length);
            SetCard(id, images[id]);
            Debug.Log("GameObject LoadScript image " + id + " loaded!");
        }
        else
            Debug.Log("uh-oh, image resources not found!");
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

// randomly select card from Resources and makes card inactive on mouse down
public class Experiment4
{
    Vector3 startPos = new Vector3(-6, -2, 0);
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 2.5f;
    public const int maxCards = 4;
    GameObject card;
    private int _id;
    public int Id { get { return _id; } }
    private System.Random rnd = new System.Random();

    public void Shuffle(Sprite[] images, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            int n = images.Length;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Sprite value = images[k];
                images[k] = images[n];
                images[n] = value;
            }
        }
    }
    public void SetCard(int id, Sprite image, float posX, float posY)
    {
        _id = id;
        //card = GameObject.Find("GameObject");
        card = new GameObject();
        card.AddComponent<SpriteRenderer>();
        //gameObject.AddComponent(System.Type.GetType("MouseScript"));
        card.AddComponent<BoxCollider>();
        card.transform.position = new Vector3(posX, posY, startPos.z);
        card.GetComponent<SpriteRenderer>().sprite = image;
    }
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("starting!");
        //card = GameObject.Find("GameObject");
        //card.AddComponent<SpriteRenderer>();
        ////gameObject.AddComponent(System.Type.GetType("MouseScript"));
        //card.AddComponent<BoxCollider>();
        //Sprite[] images = (Sprite[])Resources.LoadAll("Sprites");
        Sprite[] images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        Shuffle(images, 2);
        Debug.Log("read images " + images);
        if (images != null)
        {
            _id = 0;
            for (int i = 0; i < images.Length && i < maxCards; i++)
                //for (int i = 0; i < gridCols; i++)
            {
                //for (int j = 0; j < gridRows; j++)
                //{
                float posX = (offsetX * i) + startPos.x;
                float posY = startPos.y; // (offsetY * i) + startPos.y;
                                //GameObject nextcard = LoadScript.Instantiate(card) as GameObject;
                Sprite image = images[i];
                SetCard(i, image, posX, posY);
                Debug.Log("displaying image " + _id + " at (" + posX + "," + posY + ")");
                //}
            }
            Debug.Log("GameObject LoadScript image " + _id + " loaded!");
        }
        else
            Debug.Log("uh-oh, image resources not found!");
        Debug.Log("started.");
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