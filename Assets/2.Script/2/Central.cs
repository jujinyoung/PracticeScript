using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Central : MonoBehaviour
{
    public Transform invisibleCard;

    List<Arranger> arrangers;

    Arranger workingArranger;
    int orIndex;

    // Start is called before the first frame update
    void Start()
    {
        arrangers = new List<Arranger>();

        var arrs = transform.GetComponentsInChildren<Arranger>();

        for(int i = 0;i<arrs.Length;i++)
        {
            arrangers.Add(arrs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SwapCards(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        //현재 순서 반환(GetSiblingIndex())
        int sourindex = sour.GetSiblingIndex();
        int destindex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destindex);

        dest.SetParent(sourParent);
        //현재 순서 설정(SetSiblingIndex())
        dest.SetSiblingIndex(sourindex);
    }

    //InvisibleCard와 스왑하는 함수
    void SwapCardInHierarchy(Transform sour, Transform dest)
    {
        SwapCards(sour,dest);
 
        arrangers.ForEach(t=> t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt,pos);
    }

    public void BeginDrag(Transform card)
    {
        // Debug.Log("BeginDrag" + card.name);

        workingArranger = arrangers.Find(t => ContainPos(t.transform as RectTransform, card.position));
        orIndex = card.GetSiblingIndex();

        SwapCardInHierarchy(invisibleCard, card);
    } 
    
    public void Drag(Transform card)
    {
        // Debug.Log("Drag" + card.name);

        var whichArrangerCard = arrangers.Find(t => ContainPos(t.transform as RectTransform, card.position));
    
        //
        if(whichArrangerCard == null)
        {
            bool updateChildren = transform != invisibleCard.parent;

            invisibleCard.SetParent(transform);

            if(updateChildren)
            {
                arrangers.ForEach(t => t.UpdateChildren());
            }
        } 
        else
        {
            bool insert = invisibleCard.parent == transform;

            if(insert)
            {
                int index = whichArrangerCard.GetIndexByPosition(card);

                invisibleCard.SetParent(whichArrangerCard.transform);
                whichArrangerCard.InsertCard(invisibleCard, index);
            }
            else
            {
                int invisibleCardIndex = invisibleCard.GetSiblingIndex();
                int targetIndex = whichArrangerCard.GetIndexByPosition(card, invisibleCardIndex);

                //드래그하는 카드 위치가 인비저블카드위치와 같지 않다면 실행
                if(invisibleCardIndex != targetIndex)
                {
                    whichArrangerCard.SwapCard(invisibleCardIndex, targetIndex);
                }    
            }
            
        }
    }
    
    public void EndDrag(Transform card)
    {
        // Debug.Log("EndDrag" + card.name);
        if(invisibleCard.parent == transform)
        {
            card.SetParent(workingArranger.transform);
            workingArranger =null;
            orIndex = -1;
        }
        else
        {
            SwapCardInHierarchy(invisibleCard, card);   
        }
    }
}
