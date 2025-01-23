using UnityEngine;
using UnityEngine.EventSystems;

public class popup : MonoBehaviour ,IPointerDownHandler
{
   public GameObject PopUp;
   public DeckRecord Record;
    public void OnPointerDown(PointerEventData eventData)
    {
      // Do something when the object is clicked
        Debug.Log("Clicked on popup");
        PopUp.gameObject.SetActive(true);
        Record.LoadDeck();

    }
}
