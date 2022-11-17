using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCardLand : MonoBehaviour
{
    public Sprite cardSprite;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
        spriteRenderer.sprite = cardSprite;
        spriteRenderer.color = new Color(1, 0, 0, .5f);
        GameObject cardObject = new GameObject("landCard", typeof(SpriteRenderer));
        SpriteRenderer cardSpriteRenderer = cardObject.GetComponent<SpriteRenderer>();
        cardSpriteRenderer.sprite = cardSprite;
    }

    public void onMouseDown()
    {

        RotateLeft();
    }

    void RotateLeft()
    {
        //transform.Rotate(Vector3.forward * -90);
        Debug.Log("rotateLeft");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * -90);
        //transform.Rotate(Vector3.back);
        Debug.Log("update");  
    }
}
