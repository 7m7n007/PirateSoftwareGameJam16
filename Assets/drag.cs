
// using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private AudioClip ClickAudioClip;
    [SerializeField] private AudioClip PickAudioClip;
    // [SerializeField] private AnimationClip ShakeAnim;

    // private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Transform previousslot;
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        // rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // SoundFxManager.Instance.AudioManager(ClickAudioClip, transform, 1f);
        // GetComponent<Card>().PlayAnim(ShakeAnim);
    }
    public void OnBeginDrag(PointerEventData eventdata)
    {
        canvasGroup.blocksRaycasts = false;
        previousslot = transform.parent;
        eventdata.pointerDrag.transform.SetParent(canvas.gameObject.transform);


    }
    public void OnDrag(PointerEventData eventdata)
    {
        print("Dragging");
        // rectTransform.anchoredPosition=eventdata.position;
        eventdata.pointerDrag.GetComponent<RectTransform>().anchoredPosition += eventdata.delta / canvas.scaleFactor;
        // Vector3.Lerp(rectTransform.anchoredPosition,eventdata.delta / canvas.scaleFactor,Time.deltaTime);
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        canvasGroup.blocksRaycasts = true;
        if (eventdata.pointerDrag.transform.parent == canvas.gameObject.transform)
        {
            eventdata.pointerDrag.transform.SetParent(previousslot.transform);
        }

        eventdata.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }


}
