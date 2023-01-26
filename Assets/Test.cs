using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    IEnumerator TestCor()
    {
        Debug.Log($"Test:0 {Time.frameCount}");
        yield return null;
        Debug.Log($"Test:1 {Time.frameCount}");
        yield return null;
        Debug.Log($"Test:2 {Time.frameCount}");
        int count = 10;
        yield return new WaitUntil(() => count-- < 0);
        Debug.Log($"Test:3 {Time.frameCount}");
    }

    IEnumerator CallTestA()
    {
        Debug.Log($"CallTestA:0 {Time.frameCount}");
        yield return TestCor();
        Debug.Log($"CallTestA:1 {Time.frameCount}");
    }

    IEnumerator CallTestB()
    {
        Debug.Log($"CallTestB:0 {Time.frameCount}");
        yield return StartCoroutine(TestCor());
        Debug.Log($"CallTestB:1 {Time.frameCount}");
    }

    IEnumerator Wait()
    {
        var e = CallTestB();
        while (e.MoveNext())
        {
            yield return e.Current;
            //yield return null;
        }
    }

    void Start()
    {
        //StartCoroutine(Wait());
        StartCoroutine(CallTestA());
    }
}
