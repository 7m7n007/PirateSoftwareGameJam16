using UnityEngine;
using UnityEngine.EventSystems;

public class popupclose : MonoBehaviour ,IPointerDownHandler
{
   public GameObject PopUpclose;
   public DeckRecord Record;
    public void OnPointerDown(PointerEventData eventData)
    {
      // Do something when the object is clicked
        Debug.Log("Clicked on popup");
        PopUpclose.gameObject.SetActive(false);
        Record.SaveDeck();
        Record.ClearDeck();

    }
}