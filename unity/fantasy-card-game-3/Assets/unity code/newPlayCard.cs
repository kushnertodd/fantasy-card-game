using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class newPlayCard : MonoBehaviour
{
    Sprite cardSprite;
    SpriteRenderer cardSpriteRenderer;
    //Image m_Image;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cardObject = new GameObject("LandCard", typeof(SpriteRenderer));
        //cardSpriteRenderer = cardSpriteRenderer.GetComponent<SpriteRenderer>();
        cardSpriteRenderer = cardObject.GetComponent<SpriteRenderer>();
        cardSprite = Resources.Load("Resources/basic_land_white.jpg") as Sprite;
        cardSpriteRenderer.sprite = cardSprite;
        cardObject.transform.localScale = new Vector3(55, 1, 1);
        //m_Image = GetComponent<Image>();
        Debug.Log("sprite created!");
    }

    void RotateByDegrees()
    {
        Vector3 rotationToAdd = new Vector3(0, 90, 0);
        transform.Rotate(rotationToAdd);
    }
    int count = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { 
            RotateByDegrees();
            Debug.Log("sprite rotated " + ++count + " times!");
        }
        Debug.Log("sprite rotated " + count + " times!");

        //m_Image.sprite = cardSprite;
        //cardSpriteRenderer.sprite = cardSprite;
    }
}
