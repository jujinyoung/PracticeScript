using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class TextEffect : BaseMeshEffect
{
    Text txt;
    public Gradient myGradient;
    float gradientWaveTime;

    protected override void Start()
    {
        txt = GetComponent<Text>();
    }
    private void Update(){
        gradientWaveTime += Time.deltaTime;

        txt.FontTextureChanged();
    }
    public override void ModifyMesh(VertexHelper vh)
    {
        List<UIVertex> vertices = new List<UIVertex>();
        vh.GetUIVertexStream(vertices);

        //vertices에 x값이 제일작은것을 찾아서 넣는다.
        float min = vertices.Min(t=>t.position.x);
        //vertices에 x값이 가장 큰것을 찾아서 넣는다.
        float max = vertices.Max(t=>t.position.x);

        //vertices에 들어간 변수들에게 색을 부여함
        //순서에 따라 오른쪽에서 왼쪽, 위에서 아래 응용 가능
        for(int i = 0;i<vertices.Count;i++)
        {
            var v = vertices[i];
            float curXNormalized = Mathf.InverseLerp(min,max,v.position.x);
            curXNormalized = Mathf.PingPong(curXNormalized + gradientWaveTime, 1f);
            Color c =myGradient.Evaluate(curXNormalized);

            v.color = new Color(c.r,c.g,c.b,1);
            vertices[i] = v;
        }

        vh.Clear(); //삭제
        vh.AddUIVertexTriangleStream(vertices); 
    }
}
