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
        public bool tapped = false;
        public bool played = false;
        public bool rotating = false;
        public float total_rotation = 0;
        public float current_rotation = 0;
        public float rotation_rate;
        public float net_rotation_rate = 0.5f;
        //public  UnityEngine.Transform rotate_transform;
        public static string Dbpath = "Assets/Resources/cards/";
        public static string Imagepath = "Assets/Resources/cards/";
        public UnityCard(GameObject cardPrefab, Sprite image, float posX, float posY)
        {
            BoxCollider boxCollider = cardPrefab.GetComponent<BoxCollider>();
            //Debug.Log("UnityCard: boxCollider " + boxCollider);
            Vector3 boxSize = boxCollider.size;
            Bounds imageSize = image.bounds;
            //Debug.Log("Unitycard: image size " + imageSize.ToString());
            Vector3 size = imageSize.size;
            //Debug.Log("UnityCard: size " + size);
            float width = size.y;
            float height = size.x;
            //Debug.Log("UnityCard: height " + height + " width " + width);
            boxSize.y = width; 
            boxSize.x = height;
            boxCollider.size = boxSize;
            Bounds boxBounds = boxCollider.bounds;
            //Debug.Log("UnityCard: boxBounds " + boxBounds);
            Vector3 boxCenter = boxBounds.center;
            //Debug.Log("UnityCard: boxCenter " + boxCenter);
            boxCenter.y = 0; // width / 2;
            boxCenter.x = 0; // height / 2;
            boxCollider.center = boxCenter;

            BoardCard = GameObject.Instantiate(cardPrefab) as GameObject;
            BoardCard.GetComponent<SpriteRenderer>().sprite = image;
            BoardCard.transform.position = new Vector3(posX, posY, 0);
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
