using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text score_Text;
    static public int score_cnt = 0;
    
    // Update is called once per frame
    void Update()
    {
        score_Text.text = "Score : " + score_cnt;
    }
}
