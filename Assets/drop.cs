using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class drop : MonoBehaviour, IDropHandler
{
    public void OnDrop (PointerEventData eventData)
    {
        Debug.Log ("Dropped") ;
        if (eventData.pointerDrag != null)
        {
            if(transform.childCount <1){

            eventData.pointerDrag.transform.SetParent(this.transform);
            // eventData.pointerDrag.GetComponent<RectTransform> ().anchoredPosition = GetComponent<RectTransform> ().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;
            }
        }
    }
}
