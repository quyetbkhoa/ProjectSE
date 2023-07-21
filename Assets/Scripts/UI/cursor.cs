using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        //scale 0.1 to 0.08 in 1s and scale 0.08 to 0.1 in 1s and loop
        while (true)
        {
            float time = 0;
            while (time < 1)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(new Vector3(-0.1f, 0.1f, 0.1f), new Vector3(-0.08f, 0.08f, 0.08f), time);
                yield return null;
            }
            time = 0;
            while (time < 1)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(new Vector3(-0.08f, 0.08f, 0.08f), new Vector3(-0.1f, 0.1f, 0.1f), time);
                yield return null;
            }
        }
    }
}
