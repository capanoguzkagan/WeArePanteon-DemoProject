﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamEvent : MonoBehaviour
{
	[SerializeField] GameObject _percentText;
	[SerializeField] GameObject _rankText;
	FinishController _event;
	BrushController _brushController;
	IntroductionController _intro;
	private void Awake()
	{
		_event = FindObjectOfType<FinishController>();
		_brushController = FindObjectOfType<BrushController>();
		_intro = FindObjectOfType<IntroductionController>();
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
		_percentText.SetActive(true);
		_rankText.SetActive(false);
		_intro.Enable();
	}
}