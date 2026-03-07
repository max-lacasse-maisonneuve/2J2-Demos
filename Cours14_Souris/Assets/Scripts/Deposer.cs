using UnityEngine;
using UnityEngine.EventSystems;
public class Deposer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void AuDeposer(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;

        GameObject objetDepose = pointerEventData.pointerDrag;

        objetDepose.transform.SetParent(transform);
        objetDepose.transform.localPosition = Vector3.zero;
        objetDepose.GetComponent<Collider2D>().enabled = false;
    }
}
