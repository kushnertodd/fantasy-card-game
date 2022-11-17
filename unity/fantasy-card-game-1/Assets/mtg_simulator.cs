using fantasy_card_game_lib;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class mtg_simulator : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        transform.position = new Vector3(1.5f, 1.5f, 0.0f);
    }
    void Start()
    {
        Debug.Log("Hello world!");
        mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Errors errors = new Errors();
        //
        //*** add basic red land with 2 mana to deck on battlefield
        //
        int count = 2;
        Mana mana1 = new Mana(Mana.ManaTypeColor.Red, count);
        Land land1 = new Land("land1", mana1);
        Deck deck1 = new Deck();
        deck1.Add(land1);
        Battlefield battlefield1 = new Battlefield(deck1);
        //
        //*** play the land on the battlefield (skips over putting it in the hand and playing from the hand)
        //
        battlefield1.Play(land1, errors);
        //if (errors.Have)
        //    Assert.Fail("play land1 failed " + errors);
        //
        //*** make sure the battlefield has two red mana
        //
        int manaCount1 = battlefield1.GetManaCount(Mana.ManaTypeColor.Red);
        Assert.AreEqual(manaCount1, count, "playing land1 gave mana count " +
            manaCount1 + " instead of " + count);

        //
        //*** create creature with cost 2 red mana
        //
        Creature creature1 = new Creature("creature1", count, Mana.ManaTypeColor.Red);
        //
        //*** play the creature, make sure it succeeded
        //
        battlefield1.Play(creature1, errors);
        //if (errors.Have)
        //    Assert.Fail("play creature1 failed " + errors);
        //
        //*** playing the creature should should, should be no mana left on battlefield
        //
        int manaCount2 = battlefield1.GetManaCount(Mana.ManaTypeColor.Red);
        Assert.AreEqual(manaCount2, 0, "playing creature1 gave mana count " +
            manaCount2 + " instead of 0");
        Debug.Log("test 1 succeeded");

        //
        //*** play the land on the battlefield (again)
        //
        battlefield1.Play(land1, errors);
        //
        //*** make sure the battlefield has two red mana
        //
        int manaCount3 = battlefield1.GetManaCount(Mana.ManaTypeColor.Red);
        Assert.AreEqual(manaCount3, count, "playing land1 gave mana count " +
            manaCount1 + " instead of " + count);

        //
        //*** create creature with cost 3 red mana
        //
        Creature creature2 = new Creature(name: "creature2", cost: count + 1, costColor: Mana.ManaTypeColor.Red);
        //
        //*** play the creature
        //
        battlefield1.Play(creature2, errors);
        //
        //*** playing the creature should fail, costs too much mana
        //
        Assert.IsTrue(errors.Have, "playing creature2 gave expected error: " + errors.ToString());
        //if (errors.Have)
        //    Assert.Fail("play creature1 failed) " + errors);
        Console.WriteLine("test 2 succeeded");
        Debug.Log("test 2 succeeded");

    }
    public void helloButton()
    {
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
