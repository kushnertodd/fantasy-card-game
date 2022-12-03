using Assets.unity_code;
using fantasy_card_game_lib;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public void OnMouseDown()
    {
        Errors errors = new Errors();
        GameObject card = this.gameObject;
        UnityCard unityCard = UnityGame.FindCard(card, errors);
        if (errors.Have)
            Debug.Log(errors.ToString());
        else
        unityCard.OnMouseDown();
    }
}
