using fantasy_card_game_lib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Assets.unity_code;

public class LoadScript : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    private static bool manaChanged = false;
    private Vector3 startPos = new Vector3(-8.5f, -2, 0);
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 5.5f;
    public const float offsetY = 2.5f;
    public const int maxCards = 4;
    private UnityCard card;
    private GameObject number;
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
    }
    public static bool getManaChanged() { return manaChanged; }
    public static void setManaChanged(bool value) { manaChanged = value; }
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("starting!");
        Sprite[] images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        SetNumbers(7, 4);
        Shuffle(images, 2);
        Debug.Log("read images " + images);
        if (images != null)
        {
            for (int i = 0; i < images.Length && i < maxCards; i++)
            {
                float posX = (offsetX * i) + startPos.x;
                float posY = startPos.y;
                Sprite image = images[i];
                card = new UnityCard(cardPrefab, image, posX, posY);
                Debug.Log("displaying image " + i + " at (" + posX + "," + posY + ")");
            }
            Debug.Log("GameObject LoadScript image loaded!");
        }
        else
            Debug.Log("uh-oh, image resources not found!");
        Debug.Log("started.");
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseScript.rotating)
        {
            if (MouseScript.current_rotation == MouseScript.total_rotation)
            {
                MouseScript.rotating = false;
            }
            else
            {
                Vector3 rotationToAdd = new Vector3(0, 0, MouseScript.rotation_rate);
                MouseScript.rotate_transform.Rotate(rotationToAdd);
                MouseScript.current_rotation += MouseScript.rotation_rate;
            }
        }
        if (LoadScript.getManaChanged())
        {
            LoadScript.setManaChanged(false);
        }
    }
}
