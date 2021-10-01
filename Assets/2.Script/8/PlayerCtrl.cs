using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Gate1,
    Gate2,
    Gate3,
    Goalpoal
}
public class PlayerCtrl : MonoBehaviour
{
    public State state = State.Gate1;
    public float speed=5;
    float h;
    float v;
    Vector3 moveDir;
    public FadeInOut fadeinout;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(h,0,v).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
       
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "WALL")
        {
            var pos = col.ClosestPoint(transform.position);
            fadeinout.Fadeflow();
            switch(col.name)
            {
                case "right":
                    gameObject.transform.position = pos + new Vector3(-5,0,0);
                    break;
                case "left":
                    gameObject.transform.position = pos + new Vector3(5,0,0);
                    break;
                case "up":
                    gameObject.transform.position = pos + new Vector3(0,0,-5);
                    break;
                case "down":
                    gameObject.transform.position = pos + new Vector3(0,0,5);
                    break;    
            }  
        }
    }
}
