using fantasy_card_game_lib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LoadScript : MonoBehaviour
{
    private Experiment4 experiment = new Experiment4();
    private static bool manaChanged = false;
    public static bool getManaChanged() { return manaChanged; }
    public static void setManaChanged(bool value) { manaChanged = value; }
    // Start is called before the first frame update
    void Start()
    {
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
        Sprite image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        if (image != null)
        {
            card.AddComponent<SpriteRenderer>();
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
        Sprite image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        if (image != null)
        {
            card.AddComponent<SpriteRenderer>();
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
        card.AddComponent<BoxCollider>();
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
    private Vector3 startPos = new Vector3(-8.5f, -2, 0);
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 5.5f;
    public const float offsetY = 2.5f;
    public const int maxCards = 4;
    private GameObject card;
    private GameObject number;
    private int _id;
    public int Id { get { return _id; } }
    private System.Random rnd = new System.Random();
    private Sprite[] numbers = new Sprite[4];
    private int currentMana = 0;
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
        card = new GameObject();
        card.AddComponent<SpriteRenderer>();
        card.AddComponent<BoxCollider>();
        card.GetComponent<BoxCollider>().size = new Vector3(3, 5, 0);
        card.AddComponent<MouseScript>();
        card.transform.position = new Vector3(posX, posY, startPos.z);
        card.GetComponent<SpriteRenderer>().sprite = image;
    }
    public void SetNumbers(float posX, float posY)
    {
        number = new GameObject();
        number.AddComponent<SpriteRenderer>();
        //number.AddComponent<BoxCollider>();
        //number.AddComponent<MouseScript>();
        number.transform.position = new Vector3(posX, posY, 0);
        number.transform.localScale = new Vector3(2, 2, 1);
        numbers[0] = Resources.Load<Sprite>("Numbers/zero");
        numbers[1] = Resources.Load<Sprite>("Numbers/one");
        numbers[2] = Resources.Load<Sprite>("Numbers/two");
        numbers[3] = Resources.Load<Sprite>("Numbers/three");
        SetNumber();
    }
    public void SetNumber()
    {
        //number.GetComponent<SpriteRenderer>().sprite = numbers[currentMana];
    }
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("starting!");
        Sprite[] images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        SetNumbers(7, 4);
        Shuffle(images, 2);
        Debug.Log("read images " + images);
        if (images != null)
        {
            _id = 0;
            for (int i = 0; i < images.Length && i < maxCards; i++)
            {
                float posX = (offsetX * i) + startPos.x;
                float posY = startPos.y;
                Sprite image = images[i];
                SetCard(i, image, posX, posY);
                Debug.Log("displaying image " + _id + " at (" + posX + "," + posY + ")");
            }
            Debug.Log("GameObject LoadScript image " + _id + " loaded!");
        }
        else
            Debug.Log("uh-oh, image resources not found!");
        Debug.Log("started.");
    }

    public void OnMouseDown()
    {
        Vector3 rotationToAdd = new Vector3(0, 90, -2);
        card.transform.Rotate(rotationToAdd);
        Debug.Log("rotated LoadScript!");
    }

    // Update is called once per frame
    public void Update()
    {
        if (MouseScript.rotating)
        {
            if (MouseScript.current_rotation == MouseScript.total_rotation)
            {
                MouseScript.rotating = false;
            }
            else
            {
                //Debug.Log("Update rotating " + MouseScript.rotation_rate +
                //    " current " + MouseScript.current_rotation);
                Vector3 rotationToAdd = new Vector3(0, 0, MouseScript.rotation_rate);
                MouseScript.rotate_transform.Rotate(rotationToAdd);
                MouseScript.current_rotation += MouseScript.rotation_rate;
            }
        }
        if (LoadScript.getManaChanged())
        {
            SetNumber();
            LoadScript.setManaChanged(false);
        }
    }
}