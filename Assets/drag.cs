using System.Diagnostics.Tracing;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Transform previousslot;
    //private Vector3 ParentLocalPosition;
    private void Awake()
    {
        canvas=GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        //ParentLocalPosition = transform.parent.localPosition;
    }
    public void OnBeginDrag(PointerEventData eventdata)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        previousslot = transform.parent;
        eventdata.pointerDrag.transform.SetParent(canvas.gameObject.transform);

    }
    public void OnDrag(PointerEventData eventdata)
    {
        rectTransform.anchoredPosition += eventdata.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        // transform.localPosition = ParentLocalPosition;
        if (eventdata.pointerDrag.transform.parent == canvas.gameObject.transform)
        {
            eventdata.pointerDrag.transform.SetParent(previousslot.transform);
        }

        eventdata.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }


}
