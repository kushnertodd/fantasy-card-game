using fantasy_card_game_lib;
using System.Linq;
using UnityEngine;
using Assets.unity_code;
using System.Collections.Generic;

public class LoadScript : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    private static bool manaChanged = false;
    /*
     *  screenBOunds (10.76, 5.40)
     *  screenOrigin (-10.76, -5.40)
     *  Screen.width 1139
     *  Screen.height 574
     */
    //private Vector3 startPos = new Vector3(-8.5f, -2, 0);
    public Vector3 startPos;
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 5.5f;
    public const float offsetY = 2.5f;
    public const int maxCards = 4;
    private UnityCard card;
    private GameObject number;
    private System.Random rnd = new System.Random();
    private Sprite[] numbers = new Sprite[4];
    //private int currentMana = 0;
    public void Shuffle(List<Sprite> images, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            int n = images.Count;
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
        //private Vector3 startPos = new Vector3(-8.5f, -2, 0);
        Errors errors = new Errors();
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigin = Camera.main.ScreenToWorldPoint(Vector2.zero);
        startPos = new Vector3(screenOrigin.x, screenOrigin.y, 0);
        /*
         *  screenBOunds (10.76, 5.40)
         *  screenOrigin (-10.76, -5.40)
         */
        Debug.Log("screenBounds " + screenBounds.ToString());
        Debug.Log("screenOrigin " + screenOrigin.ToString());
        Debug.Log("Screen.width " + Screen.width.ToString());
        Debug.Log("Screen.height " + Screen.height.ToString());
        Cards cards = Cards.CreateCards(UnityCard.Dbpath + "cards.db", errors);
        if (errors.Have)
        {
            Debug.Log("errors on reading cards.db: " + errors.ToString());
        }
        List<Sprite> images = new List<Sprite>();
        foreach (Card card in cards.cardList)
        {
            string fileName = UnityCard.Imagepath + card.FileName;
            Sprite sprite = UnityUtils.LoadNewSprite(fileName, errors);
            if (sprite != null)
            {
                images.Add(UnityUtils.LoadNewSprite(fileName, errors));
                Debug.Log("read image " + fileName);
            }
            else
                Debug.Log("error reading image " + fileName + ": " + errors.ToString());
        }
        //Sprite[] images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
        SetNumbers(7, 4);
        Shuffle(images, 2);
        Debug.Log("read " + images.Count + " images");
        if (images != null)
        {
            for (int i = 0; i < images.Count && i < maxCards; i++)
            {
                float posX = (offsetX * i) + startPos.x;
                float posY = startPos.y;
                Sprite image = images[i];
                Rect rect = image.rect;
                Debug.Log("image rect " + rect);
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
        foreach (UnityCard unityCard in UnityCard.unityCards)
        {
            if (unityCard.rotating)
            {
                if (unityCard.current_rotation == unityCard.total_rotation)
                {
                    unityCard.rotating = false;
                }
                else
                {
                    Vector3 rotationToAdd = new Vector3(0, 0, unityCard.rotation_rate);
                    unityCard.BoardCard.transform.Rotate(rotationToAdd);
                    unityCard.current_rotation += unityCard.rotation_rate;
                }
            }
            if (LoadScript.getManaChanged())
            {
                LoadScript.setManaChanged(false);
            }
        }
    }
}
