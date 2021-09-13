using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;
    // Start is called before the first frame update
    void Start()
    {
        root = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //BroadcastMessage("함수 이름",파라미터,이러한 함수를 찾지 못해도 오류가 나지 않는다)
        root.BroadcastMessage("BeginDrag",transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //카드가 포인터를 따라다님
        transform.position = eventData.position;
        root.BroadcastMessage("Drag",transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag",transform, SendMessageOptions.DontRequireReceiver);
    }
}
