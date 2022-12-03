using fantasy_card_game_lib;
using System.Linq;
using UnityEngine;
using Assets.unity_code;
using System.Collections.Generic;


public class LoadScript : MonoBehaviour
{
    private UnityGame unityGame;
    // Start is called before the first frame update
    void Start()
    {
        unityGame = new UnityGame();
        unityGame.Start();
    }

    // Update is called once per frame
    void Update()
    {
        unityGame.Update();
    }
}
