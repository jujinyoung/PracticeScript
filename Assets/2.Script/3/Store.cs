using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Transform slotRoot;  //slots
    public ItemBuffer itemBuffer; // Class ItemBuffer
    List<Slot> slots;
    public System.Action<ItemProperty> onSlotClick;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        //slotRoot의 자식들을 가져온다.
        int slotCnt = slotRoot.childCount;

        for(int i = 0; i<slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            //아이템의 개수만큼 새고 이미지를 바꾼다.
            if(i<itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else
            {
                //아이템이 없을경우 상호작용을 없앤다.
                slot.GetComponent<Button>().interactable = false;
            }

            slots.Add(slot);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSlot(Slot slot)
    {

        if(onSlotClick != null)
        {
            onSlotClick(slot.item);
        }
    }
}
