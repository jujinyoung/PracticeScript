using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float startTime;
    public float minX,maxX;
    [Range(1,100)]
    public float moveSpeed;
    private int sign = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //게임이 시작하고 startTime만큼의 시간이 흘렀을떄 움직이는 로직
        if(Time.time >= startTime)
        {
            //이동 로직 처리
            transform.position += new Vector3(moveSpeed*Time.deltaTime*sign,0,0); 

            if(transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }
}
