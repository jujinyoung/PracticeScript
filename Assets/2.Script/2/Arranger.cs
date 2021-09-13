using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    List<Transform> children;
    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();

        UpdateChildren();
    }

    // Update is called once per frame
    public void UpdateChildren()
    {
        for(int i = 0; i<transform.childCount; i++)
        {
            //사이즈가 작다면 늘린다.
            if(i==children.Count)
            {
                children.Add(null);
            }

            var child = transform.GetChild(i);

            if(child !=children[i])
            {
                children[i] = child;
            }
        }
        //RemoveRange(int, int) = 앞에 적힌 부분부터 뒤에 부분까지 삭제
        children.RemoveRange(transform.childCount, children.Count - transform.childCount);
    }

    public void InsertCard(Transform card, int index)
    {
        children.Add(card);
        card.SetSiblingIndex(index);
        UpdateChildren();
    }


    public int GetIndexByPosition(Transform card, int skipIndex = -1)
    {
        int result = 0;

        for(int i = 0; i< children.Count; i++)
        {
            if(card.position.x < children[i].position.x)
            {
                break;
            }else if(skipIndex != i)
            {
                result++;
            }
        }

        return result;
    }

    public void SwapCard(int index01,int index02)
    {
        Central.SwapCards(children[index01],children[index02]);
        UpdateChildren();
    }
}
