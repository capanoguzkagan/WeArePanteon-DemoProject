using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
	private List<Vector3> _childPositions;
	private List<Quaternion> _childRotations;
	private Animator _anim;
	private void Awake()
	{
		_childPositions = new List<Vector3>();
		_childRotations = new List<Quaternion>();
		GetTPose();
	//	RagDollOn(false);	
	}
	// Update is called once per frame
	public void ResetRagdoll()
	{
	//	RagDollOn(false);
		Transform[] children = GetComponentsInChildren<Transform>();
		for (int i = 0; i < children.Length; i++)
		{
			children[i].localPosition = _childPositions[i];
			children[i].localRotation = _childRotations[i];
		}
	}
	/*public	void RagDollOn(bool ragdoll)
	{
		Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
		foreach (var rb in bodies)
		{
			rb.isKinematic = !ragdoll;
		}
		_anim.enabled = !ragdoll;
	}*/
	private void GetTPose()
	{
		Transform[] children = GetComponentsInChildren<Transform>();
		foreach (var trans in children)
		{
			_childPositions.Add(trans.localPosition);
			_childRotations.Add(trans.localRotation);
		}
	}
}
