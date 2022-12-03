using fantasy_card_game_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.unity_code
{
    enum GameState
    {
        Start,
        HandDealed
    }
    public class UnityGame
    {
        // where the database file cards.db lives
        public static string Dbpath = "Assets/Resources/cards/";
        // where the card front images live
        public static string Imagepath = "Assets/Resources/cards/";
        // static game state
        public static List<UnityCard> unityCards = new List<UnityCard>();
        public static bool manaChanged;
        public static GameObject cardPrefab;
        private static GameState gameState = GameState.Start;

        public const int maxCards = 4;
        private GameObject number;
        private static System.Random rnd = new System.Random();
        private Sprite[] numbers = new Sprite[4];

        /*
         *  screenBOunds (10.76, 5.40)
         *  screenOrigin (-10.76, -5.40)
         *  Screen.width 1139
         *  Screen.height 574
         */
        public const int gridRows = 2;
        public const int gridCols = 4;
        public const float offsetX = 5.5f;
        public const float offsetY = 2.5f;
        public static Vector3 startPos; //  = new Vector3(-8.5f, -2, 0);
        public UnityGame()
        {
            cardPrefab = Resources.Load<GameObject>("CardPrefab");
        }
        public void AddCard(UnityCard card)
        {
            unityCards.Add(card);
        }
        public static UnityCard FindCard(GameObject card, Errors errors)
        {
            Debug.Log("UnityCard.findCard: looking for " + card.ToString());
            foreach (UnityCard unityCard in UnityGame.unityCards)
            {
                Debug.Log("UnityCard.findCard: checking for " + card.ToString());
                if (unityCard.BoardCard == card)
                    return unityCard;
            }
            errors.Add(Errors.MessageId.MISC_TEXT, "OnMouseDown: cound not find card");
            return null;
        }
        public static void OnMouseDown(UnityCard unityCard)
        {
            if (unityCard.BoardCard.tag == "Library")
            {
                gameState = GameState.HandDealed;
                Errors errors = new Errors();
                Cards cards = Cards.CreateCards(UnityGame.Dbpath + "cards.db", errors);
                if (errors.Have)
                {
                    Debug.Log("errors on reading cards.db: " + errors.ToString());
                }
                List<Sprite> images = new List<Sprite>();
                foreach (Card card in cards.cardList)
                {
                    string fileName = UnityGame.Imagepath + card.FileName;
                    Sprite sprite = UnityUtils.LoadNewSprite(fileName, errors);
                    if (sprite != null)
                    {
                        images.Add(UnityUtils.LoadNewSprite(fileName, errors));
                        Debug.Log("read image " + fileName);
                    }
                    else
                        Debug.Log("error reading image " + fileName + ": " + errors.ToString());
                }
                Shuffle(images, 3);
                Debug.Log("read " + images.Count + " images");
                if (images != null)
                {
                    for (int i = 0; i < images.Count && i < maxCards; i++)
                    {
                        Sprite image = images[i];
                        Rect rect = image.rect;
                        Debug.Log("image rect " + rect);
                        //float posX = (offsetX * i) + startPos.x;
                        float posX = rect.height / 200 * i * 1.1f + startPos.x;
                        float posY = startPos.y;
                        UnityCard card = new UnityCard(
                            //cardPrefab,
                            image, posX, posY, "HandCard");
                        Debug.Log("displaying image " + i + " at (" + posX + "," + posY + ")");
                    }
                }
                else
                    Debug.Log("uh-oh, image resources not found!");
            }
            else
            {
                Debug.Log("UnityGame.OnMouseDown: unrecognized unityCard tag " + unityCard.BoardCard.tag);
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

        public void SetupGame()
        {
            Errors errors = new Errors();
            //Sprite[] images = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();
            SetNumbers(7, 4);
            string cardBackFileName = UnityGame.Imagepath + "card.back.jpg";
            Sprite cardBack = UnityUtils.LoadNewSprite(cardBackFileName, errors);
            if (cardBack != null)
            {
                Rect rect = cardBack.rect;
                float posX = rect.height / 200 * maxCards * 1.1f + startPos.x;
                float posY = startPos.y;
                UnityCard card = new UnityCard(
                    //cardPrefab,
                    cardBack, posX, posY,
                    "Library");
                // add card to global card list so can find from MouseScript on mouse click
                unityCards.Add(card);
            }
            Debug.Log("GameObject LoadScript image loaded!");
        }

        public static void Shuffle(List<Sprite> images, int count = 1)
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
        public void Start()
        {
            Debug.Log("starting!");
            //private Vector3 startPos = new Vector3(-8.5f, -2, 0);
            Errors errors = new Errors();
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Vector2 screenOrigin = Camera.main.ScreenToWorldPoint(Vector2.zero);
            startPos = new Vector3(screenOrigin.x * 3 / 4, screenOrigin.y / 2, 0);
            /*
             *  screenBOunds (10.76, 5.40)
             *  screenOrigin (-10.76, -5.40)
             */
            Debug.Log("screenBounds " + screenBounds.ToString());
            Debug.Log("screenOrigin " + screenOrigin.ToString());
            Debug.Log("Screen.width " + Screen.width.ToString());
            Debug.Log("Screen.height " + Screen.height.ToString());
            SetupGame();
            Debug.Log("started.");
        }
        public void Update()
        {
            foreach (UnityCard unityCard in UnityGame.unityCards)
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
                if (manaChanged)
                {
                    manaChanged = false;
                }
            }
        }
    }
}
