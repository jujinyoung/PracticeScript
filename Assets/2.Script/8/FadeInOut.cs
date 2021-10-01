using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    float waitTime = 2.0f;

    public void Fadein(float waitTime)
    {
        StartCoroutine(FadeIn(waitTime));
    }

    public void Fadeout()
    {
        StartCoroutine(FadeOut());
    }

    public void Fadeflow()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeIn(float waitTime)
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime /F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator FadeOut()
    {
        Color alpha = Panel.color;
        while(alpha.a > 0f)
        {
            time += Time.deltaTime /F_time;
            alpha.a = Mathf.Lerp(1,0,time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        Panel.gameObject.SetActive(false);

        yield return null;
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime /F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(1.0f);
        while(alpha.a > 0f)
        {
            time += Time.deltaTime /F_time;
            alpha.a = Mathf.Lerp(1,0,time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        Panel.gameObject.SetActive(false);

        yield return null;
    }
}
