using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 2.0f;
	private Player playerInput;
	private Animator _anim;
	private Rigidbody _rb;
	private PlayerController _player;
	private void Awake()
	{
		playerInput = new Player();
		_rb = GetComponent<Rigidbody>();
		_anim = GetComponentInChildren<Animator>();
		_player = GetComponent<PlayerController>();

	}
	private void OnEnable()
	{
		playerInput.Enable();
	}
	private void OnDisable()
	{
		playerInput.Disable();
	}
	void Update()
	{
		Movement();


	}
	private void Movement()
	{
		Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
		Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
		_rb.velocity = move * playerSpeed;

		if (move != Vector3.zero)
		{
			_anim.SetBool("Trigger", true);
			gameObject.transform.forward = move;
		}
		else
		{
			_anim.SetBool("Trigger", false);
		}
	}
	public void VictoryAnim()
	{
		_anim.Play("Victory");
	}
	private void OnTriggerEnter(Collider other)
	{
		NavAgentController _opponent = other.GetComponent<NavAgentController>();
		if (other.gameObject.tag=="Obstacle")
		{
			_anim.SetBool("Impact",true);
			_player.enabled = false;
			StartCoroutine(AnimDelay());
		}
		if (_opponent!=null)
		{
			_anim.SetBool("Impact", true);
			_player.enabled = false;
			StartCoroutine(Impact());
			_opponent.Impact();
		}
	}
	IEnumerator AnimDelay()
	{
		yield return new WaitForSeconds(0.5f);
		_player.enabled = true;
		_anim.SetBool("Impact", false);
		this.transform.position = new Vector3(0, 0.0063f, 0);
	}
	IEnumerator Impact()
	{
		yield return new WaitForSeconds(0.5f);
		_player.enabled = true;
		_anim.SetBool("Impact", false);
	}
}

