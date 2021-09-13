using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour
{
    public GameObject popup;
    Animator anim;
    public  static PopupSystem instance{get;private set;}
    public Text txtTitle,txtContent;
    Action onClickOkay,onClickCancel;
    private void Awake()
    {
        instance = this;
        anim = popup.GetComponent<Animator>();
    }

    private void Update()
    {
        //현재애니메이터의 스테이트를 받아온다.
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("close"))
        {
            //애니메이션이 끝났을 떄 재생
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                popup.SetActive(false);
            }
        }    
    }
    
    public void OpenPopUp(string title,string content,Action onClickOkay,Action onClickCancel)
    {
        txtTitle.text = title;
        txtContent.text = content;
        this.onClickOkay = onClickOkay;
        this.onClickCancel = onClickCancel;
        popup.SetActive(true);
    }

    public void OnClickOkay()
    {
        if(onClickOkay != null)
        {
            onClickOkay();
        }

        ClosePopup();
    }
    
    public void OnClickCancel()
    {
        if(onClickCancel != null)
        {
            onClickCancel();
        }

        ClosePopup();
    }

    void ClosePopup()
    {
        anim.SetTrigger("close");
    }
}
