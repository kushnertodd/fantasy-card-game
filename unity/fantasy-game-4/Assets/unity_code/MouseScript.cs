using Assets.unity_code;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameObject card = this.gameObject;
        UnityCard unityCard = UnityCard.findCard(card);
        unityCard.OnMouseDown();
    }
}
