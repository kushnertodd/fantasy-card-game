using fantasy_card_game_lib;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.unity_code
{
    public class UnityCard
    {
        public GameObject BoardCard { get; set; }
        public CardType cardType;
        public string Tag { get; set; }
        private GameObject cardPrefab;
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

        public UnityCard(
            //GameObject cardPrefab, 
            Sprite image, float posX, float posY, string tag, CardType cardType)
        {
            this.cardPrefab = UnityGame.cardPrefab;
            this.cardType = cardType;
            this.Tag = tag;
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
        }

        public void OnMouseDown()
        {
            if (Tag == "Library")
            {
                UnityGame.OnMouseDown(this);
            }
            else if (Tag == "HandCard")
            {
                if (!played)
                {
                    Vector3 pos = BoardCard.transform.position;
                    pos.y = pos.y + 5;
                    BoardCard.transform.position = pos;
                    played = true;
                    if (cardType == CardType.Land)
                    {
                        UnityGame.manaChanged= true;
                        UnityGame.manaCount++;
                        //UnityGame.number.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(
                        //UnityGame.numbers[UnityGame.manaCount]);
                    }
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
                        UnityGame.manaChanged = true;
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
            else
            {
                Debug.Log("UnityCard.OnMouseDown: unrecognized unityCard tag " + Tag);
            }
            UnityGame.OnMouseDown(this);
        }
    }
}
