using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_ : MonoBehaviour
{
    public Transform rootSlot;
    public Store store;
    List<Slot> slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();

        int slotCnt = rootSlot.childCount;

        for(int i = 0; i<slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }

        store.onSlotClick += BuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        //slots의 리스트를 0번쨰 인덱스부터 찾는다.
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });

        if(emptySlot != null)
        {
            emptySlot.SetItem(item);
        }
    }
}
