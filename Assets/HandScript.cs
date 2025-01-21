using UnityEngine;

public class HandScript : MonoBehaviour
{
    [SerializeField] GameObject EmptySlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float childCount=transform.childCount;
        float width=gameObject.GetComponent<RectTransform>().sizeDelta.x;
        for (int i = 0;i<childCount;i++){
            Vector3 oldposition=transform.GetChild(i).localPosition;
            // transform.GetChild(i).position=new Vector3((i*(gameObject.GetComponent<RectTransform>().sizeDelta.x/transform.childCount))+(gameObject.GetComponent<RectTransform>().sizeDelta.x/2),oldposition.y,oldposition.z);
            transform.GetChild(i).transform.localPosition=new Vector3(((i)*width/childCount)-((childCount-1)/2f)*width/childCount,oldposition.y,oldposition.y);
        }

    }
    public GameObject createSlot(){
        GameObject newSlot=Instantiate(EmptySlot,transform);
        return(newSlot);
    }
}
