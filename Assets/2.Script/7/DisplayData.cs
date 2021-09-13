using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayData : MonoBehaviour
{
    public Image img;
    public Text text;

    // public Data data;
    
    //play를 안해도 바로 바뀜.(null 체크 필수)
    // private void OnValidate()
    // {
    //     img.color = data.color;
    //     text.text = data.name;   
    // }
    // Start is called before the first frame update
    void Start()
    {
        Data data = Resources.Load<Data>("Data01"); 

        img.color = data.color;
        text.text = data.name;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
