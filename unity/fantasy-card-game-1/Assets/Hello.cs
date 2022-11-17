using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        Debug.Log("clicked1");
        //RotateLeft();
    }
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public void LoadSprite()
    {
        newSprite = Resources.Load("Resources/basic_land_white_sprite.jpg") as Sprite;
        spriteRenderer = new SpriteRenderer();
        spriteRenderer.sprite = newSprite;
        Debug.Log("sprite created!");
    }
    //public void RotateLeft()
    //{
    //    Quaternion theRotation = transform.localRotation;
    //    theRotation.z *= 270;
    //    transform.localRotation = theRotation;
    //    Debug.Log("RotateLeft called");
    //    //LoadSprite();
    //}
//    public void hello()
//    {
//        Debug.Log("hello");
//    }
}
