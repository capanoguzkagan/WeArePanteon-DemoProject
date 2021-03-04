using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamEvent : MonoBehaviour
{
	FinishController _event;
	private void Awake()
	{
		_event =FindObjectOfType<FinishController>();
	}

	private void OnEnable()
	{
		_event.FinishEvent += HandleFinishEvent;
	}

	private void HandleFinishEvent()
	{
		this.gameObject.SetActive(false);
	}
}
