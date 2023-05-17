using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTest : MonoBehaviour
{
	[SerializeField]
	CoroutineManager manager;

	private void Start()
	{
		manager.StartCoroutine(ErrorTest());
		Destroy(gameObject);
	}
	IEnumerator ErrorTest()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("hoge");
		yield return new WaitForSeconds(2f);
		Debug.Log("finish");
		if (gameObject == null)
		{
			Debug.Log("destroyed");
		}
	}
}
