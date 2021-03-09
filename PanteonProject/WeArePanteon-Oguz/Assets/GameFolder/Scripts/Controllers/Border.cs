using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
	void Update()
	{
			transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, xMin, xMax),
			Mathf.Clamp(transform.position.y, yMin, yMax),
			Mathf.Clamp(transform.position.z, zMin, zMax)
			);
	}
}
