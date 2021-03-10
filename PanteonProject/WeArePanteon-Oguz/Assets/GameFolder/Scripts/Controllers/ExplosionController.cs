using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	[SerializeField] private float _force;
	[SerializeField] private float _radius;
	// Start is called before the first frame update

	private void OnTriggerEnter(Collider other)
	{
		Explosion();
	}
	private void Explosion()
	{

		Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

		foreach (Collider nearbyObject in colliders)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb!=null)
			{
				rb.AddExplosionForce(_force, transform.position, _radius);
			}
		}
	}
}
