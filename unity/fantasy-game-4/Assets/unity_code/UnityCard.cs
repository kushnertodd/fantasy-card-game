using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Networking.Types;

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
        public UnityCard(GameObject cardPrefab, Sprite image, float posX, float posY)
        {
            BoardCard = GameObject.Instantiate(cardPrefab) as GameObject;
            BoardCard.transform.position = new Vector3(posX, posY, 0);
            BoardCard.GetComponent<SpriteRenderer>().sprite = image;
            unityCards.Add(this);
        }
        public static UnityCard findCard(GameObject card)
        {
            foreach (UnityCard unityCard in unityCards)
            {
                if (unityCard.BoardCard == card)
                    return unityCard;
            }
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
