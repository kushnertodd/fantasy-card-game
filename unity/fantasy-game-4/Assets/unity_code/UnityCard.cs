using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.unity_code
{
    public class UnityCard
    {
        public GameObject BoardCard { get; set; }
        public UnityCard(GameObject cardPrefab, Sprite image, float posX, float posY)
        {
            BoardCard = GameObject.Instantiate(cardPrefab) as GameObject;
            BoardCard.transform.position = new Vector3(posX, posY, 0);
            BoardCard.GetComponent<SpriteRenderer>().sprite = image;
        }
    }
}
