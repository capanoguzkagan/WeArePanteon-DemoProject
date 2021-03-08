using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformController : MonoBehaviour
{
	[SerializeField] bool _turnReverse;
	Transform _firtTrans;
	Transform _firtTransOpp;
	private void FixedUpdate()
	{
		Rotation();
	}
	private void Rotation()
	{
		if (_turnReverse)
		this.transform.Rotate(0.0f, 0.0f, 0.35f);
		else
		this.transform.Rotate(0.0f, 0.0f, -0.35f);

	}
	private void OnTriggerEnter(Collider other)
	{
		PlayerController _player = other.GetComponent<PlayerController>();
		NavAgentController _opponent = other.GetComponent<NavAgentController>();
		if (_player!=null)
		{
			_firtTrans = _player.transform.parent;
			_player.transform.parent = this.transform;
		}		
		if (_opponent!=null)
		{
			_firtTransOpp = _opponent.transform.parent;
			_opponent.transform.parent = this.transform;
		}
	}	
	private void OnTriggerExit(Collider other)
	{
		PlayerController _player = other.GetComponent<PlayerController>();
		NavAgentController _opponent = other.GetComponent<NavAgentController>();
		if (_player!=null)
		{
			_player.transform.parent = _firtTrans;
		}		
		if (_opponent!=null)
		{
			_opponent.transform.parent = _firtTrans;
		}
	}
}
