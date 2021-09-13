using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCLickMyButton()
    {
        PopupSystem.instance.OpenPopUp(
            "jjy",
            "이건 팝업시스템 입니다. 레이아웃활용과 UI배치, 스크립트는 Action 레퍼런스의 활용 등등을 이용합니다.",
        () =>
        {
            Debug.Log("OnClick Okay");
        },
        () =>
        {
            Debug.Log("OnClick Cancel");
        }
        );
    }
}
