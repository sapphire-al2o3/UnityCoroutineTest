using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    IEnumerator TestCor()
    {
        yield return null;
        Debug.Log($"Test:0 {Time.frameCount}");
        yield return null;
        Debug.Log($"Test:1 {Time.frameCount}");
        yield return new WaitForSeconds(0.1f);
        Debug.Log($"Test:2 {Time.frameCount}");
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
            //yield return e.Current;
            yield return null;
        }
    }

    void Start()
    {
        //StartCoroutine(Wait());
        StartCoroutine(CallTestA());
    }
}
