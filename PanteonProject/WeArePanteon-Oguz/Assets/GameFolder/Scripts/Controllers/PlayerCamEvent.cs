using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamEvent : MonoBehaviour
{
	FinishController _event;
	BrushController _brushController;
	private void Awake()
	{
		_event = FindObjectOfType<FinishController>();
		_brushController = FindObjectOfType<BrushController>();
	}

	private void OnEnable()
	{
		_event.FinishEvent += HandleFinishEvent;
	}

	private void HandleFinishEvent()
	{
		StartCoroutine(Delay());
	}
	IEnumerator Delay()
	{
		yield return new WaitForSeconds(1f);
		this.gameObject.SetActive(false);
		_brushController.enabled = true;
	}
}