using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingMechanic : MonoBehaviour
{
	[SerializeField] bool _isLeft;
	[SerializeField] float _pushForce;

	private void OnTriggerEnter(Collider other)
	{
		Rigidbody rb = other.GetComponent<Rigidbody>();

		if (rb!=null)
		{
			if (_isLeft)
				rb.AddTorque(transform.up * _pushForce);

			else
				rb.AddRelativeForce(Vector3.back * _pushForce*Time.deltaTime);	
		}
	}
}
