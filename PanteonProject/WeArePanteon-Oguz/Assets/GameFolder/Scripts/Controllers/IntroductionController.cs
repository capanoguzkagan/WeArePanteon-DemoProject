using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionController : MonoBehaviour
{
	private void OnEnable()
	{
		StartCoroutine(Disable());
	}
	IEnumerator Disable()
	{
		yield return new WaitForSecondsRealtime(2f);
		this.gameObject.SetActive(false);
	}
	public void Enable()
	{
		this.gameObject.SetActive(true);
	}
}
