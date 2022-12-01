using UnityEngine;

public class LandCard : MonoBehaviour 
{
    [SerializeField] GameObject card;
    //[SerializeField] Sprite image;
    // Start is called before the first frame update
    private void Start()
    {
        // var image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        Sprite image = Resources.Load<Sprite>("Sprites/basic_land_edit_again");
        if (image != null)
        {
            GetComponent<SpriteRenderer>().sprite = image;
            gameObject.AddComponent(System.Type.GetType("LoadScript"));
            //Debug.Log("ready to roll...");
        }
        else
            Debug.Log("uh-oh, 'basic_land_edit.png' not found!");
    }
    
    public void OnMouseDown()
    {
        if (card.activeSelf)
        {
            card.SetActive(false);
        }
        Debug.Log("testing 1 2 3");
    }
}
