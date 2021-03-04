using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
	public event System.Action FinishEvent;
	private void OnTriggerEnter(Collider other)
	{
		PlayerController _player = other.GetComponent<PlayerController>();
		if (_player!=null)
		{
			FinishEvent?.Invoke();
		}
	}
}
