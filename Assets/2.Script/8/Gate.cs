using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(gameObject.tag == "GATE"){
            Score.score_cnt += 1;
        }
        if(gameObject.tag == "GOAL"){
            Score.score_cnt += 1;
        }
    }
}
