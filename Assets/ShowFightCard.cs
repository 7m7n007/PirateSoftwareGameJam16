// using Unity.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowFightCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  public GameObject CardCanvas;
  [SerializeField] GameObject blankCard;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public void Start()
  {
    CardCanvas = GameObject.FindGameObjectWithTag("Respawn");
  }
  public void OnPointerDown(PointerEventData eventData)
  {
    if (Input.GetMouseButtonDown(1))
    {
      // Debug.Log("holding pointer");

      GameObject newcard = Instantiate(blankCard, CardCanvas.transform.GetChild(0));
      // newcard.GetComponentInChildren<Card>().isUnit=false;
      newcard.GetComponent<VisualCard>().Attack.text=gameObject.GetComponent<Card>().CardAttack.ToString();
      newcard.GetComponent<VisualCard>().Health.text=gameObject.GetComponent<Card>().CardHealth.ToString();
      newcard.GetComponent<VisualCard>().Description.text=gameObject.GetComponent<Card>().CardDesc.ToString();
      newcard.GetComponent<VisualCard>().sprite.sprite=gameObject.GetComponent<Card>().CardSprite;
      // newcard.transform.localScale = new Vector3(6, 6, 1);
    }
  }
  public void OnPointerUp(PointerEventData eventData)
  {
    if (Input.GetMouseButtonUp(1))
    {
      Debug.Log("releasing pointer");

      Destroy(CardCanvas.transform.GetChild(0).GetChild(0).gameObject);
    }
  }
}

