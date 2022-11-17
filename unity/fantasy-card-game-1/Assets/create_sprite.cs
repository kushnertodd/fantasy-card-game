using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_sprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public void LoadSprite()
    {
        newSprite = Resources.Load("Resources/basic_land_white_sprite.jpg") as Sprite;
        spriteRenderer.sprite = newSprite;
        Debug.Log("sprite created!");
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
