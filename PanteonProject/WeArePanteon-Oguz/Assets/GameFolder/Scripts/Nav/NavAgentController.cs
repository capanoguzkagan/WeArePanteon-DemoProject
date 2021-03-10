﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour
{
	[SerializeField] Transform _StartPoint;
	[SerializeField] GameObject _ragdollObject;
	private RagdollController _ragdoll;
	NavMeshAgent _nMesh;
	Animator _anim;
	float _speedID;
	private void Awake()
	{
		_anim = GetComponentInChildren<Animator>();
		_nMesh= GetComponent<NavMeshAgent>();
		_nMesh.destination = new Vector3(0, 0, 6.5f);
		_ragdoll = GetComponent<RagdollController>();
	}
	private void Start()
	{
		_ragdollObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
    {
		_speedID = _nMesh.speed;
		_anim.SetFloat("Speed", _speedID);
	}
	private void OnTriggerEnter(Collider other)
	{
		FinishController _finish = other.GetComponent<FinishController>();
		NavAgentController _opponent = other.GetComponent<NavAgentController>();
		if (other.gameObject.tag == "Obstacle")
		{
			_anim.SetBool("Impact", true);
			StartCoroutine(AnimDelay());
			_nMesh.speed = 0;
			_nMesh.enabled = false;
		}
		if (other.gameObject.tag == "ObstacleExp")
		{
			_nMesh.speed = 0;
			_nMesh.enabled = false;
			_anim.enabled = false;
			_ragdollObject.SetActive(true);
			StartCoroutine(Explosion());
		}
		if (_finish!=null)
		{
			StartCoroutine(Finish());

		}
		if (_opponent!=null)
		{
			Impact();
		}

	}
	public void Impact()
	{
		_anim.SetBool("Impact", true);
		StartCoroutine(ImpactPlayer());
		_nMesh.speed = 0;
		_nMesh.enabled = false;
	}
	IEnumerator AnimDelay()
	{
		yield return new WaitForSeconds(0.5f);
		_nMesh.speed = 0.3f;
		_anim.SetBool("Impact", false);
		this.transform.position = _StartPoint.transform.position;
		_nMesh.enabled = true;
		_nMesh.destination =new Vector3 (0,0,6.5f);
	}
	IEnumerator ImpactPlayer()
	{
		yield return new WaitForSeconds(0.5f);
		_nMesh.speed = 0.3f;
		_anim.SetBool("Impact", false);
		_nMesh.enabled = true;
		_nMesh.destination = new Vector3(0, 0, 6.5f); 
	}
	IEnumerator Finish()
	{
		yield return new WaitForSeconds(0.75f);
		_nMesh.speed = 0;
		_nMesh.enabled = false;
		_anim.Play("Victory");
	}
	IEnumerator Explosion()
	{
		yield return new WaitForSeconds(1f);
		_nMesh.enabled = true;
		_nMesh.speed = 0.3f;
		_ragdoll.ResetRagdoll();
		_ragdollObject.SetActive(false);
		_anim.enabled = true;
		_nMesh.destination = new Vector3(0, 0, 6.5f);

	}
}
