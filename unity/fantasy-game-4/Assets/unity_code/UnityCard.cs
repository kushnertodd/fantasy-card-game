using fantasy_card_game_lib;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Assets.unity_code
{
    public class UnityCard
    {
        public GameObject BoardCard { get; set; }
        public static List<UnityCard> unityCards = new List<UnityCard>();
        // initial state for cards
        public bool tapped = false;
        public bool played = false;
        public bool rotating = false;
        // variables used for rotation
        public float total_rotation = 0;
        public float current_rotation = 0;
        public float rotation_rate;
        // speed at which cards rotate when tapped, positive for tapping, negative for untapping
        public float net_rotation_rate = 0.5f;
        // where the database file cards.db lives
        public static string Dbpath = "Assets/Resources/cards/";
        // where the card front images live
        public static string Imagepath = "Assets/Resources/cards/";
        public UnityCard(GameObject cardPrefab, Sprite image, float posX, float posY)
        {
            // boxcollider controlling where mouse clicks are picked up
            BoxCollider boxCollider = cardPrefab.GetComponent<BoxCollider>();
            // get image size
            Bounds imageSize = image.bounds;
            Vector3 size = imageSize.size;
            float width = size.y;
            float height = size.x;
            // set boxcollider size to size of the card image
            Vector3 boxSize = boxCollider.size;
            boxSize.y = width; 
            boxSize.x = height;
            boxCollider.size = boxSize;
            Bounds boxBounds = boxCollider.bounds;
            // create board card from prefab
            BoardCard = GameObject.Instantiate(cardPrefab) as GameObject;
            // set sprite to image
            BoardCard.GetComponent<SpriteRenderer>().sprite = image;
            // move card to position
            BoardCard.transform.position = new Vector3(posX, posY, 0);
            // add card to global card list so can find from MouseScript on mouse click
            unityCards.Add(this);
        }
        public static UnityCard findCard(GameObject card, Errors errors)
        {
            Debug.Log("UnityCard.findCard: looking for " + card.ToString());
            foreach (UnityCard unityCard in unityCards)
            {
                Debug.Log("UnityCard.findCard: checking for " + card.ToString());
                if (unityCard.BoardCard == card)
                    return unityCard;
            }
            errors.Add(Errors.MessageId.MISC_TEXT, "OnMouseDown: cound not find card");
            return null;
        }
        public void OnMouseDown()
        {
            if (!played)
            {
                Vector3 pos = BoardCard.transform.position;
                pos.y = pos.y + 5;
                BoardCard.transform.position = pos;
                played = true;
            }
            else
            if (!rotating)
            {
                //rotate_transform = BoardCard.transform;
                if (!tapped)
                {
                    tapped = true;
                    rotation_rate = net_rotation_rate;
                    current_rotation = 0;
                    total_rotation = 90;
                    LoadScript.setManaChanged(true);
                    Debug.Log("rotated untapped mousescript!");
                }
                else
                {
                    tapped = false;
                    rotation_rate = -net_rotation_rate;
                    current_rotation = 0;
                    total_rotation = -90;
                    Debug.Log("rotated tapped mousescript!");
                }
                rotating = true;
            }
        }
    }
}
