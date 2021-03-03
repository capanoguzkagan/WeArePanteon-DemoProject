using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 2.0f;
	private Player playerInput;
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float gravityValue = -9.81f;
	private Animator _anim;
	private void Awake()
	{
		playerInput = new Player();
		controller = GetComponent<CharacterController>();
		_anim = GetComponentInChildren<Animator>();

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
		//Animation();
	}
	private void Movement()
	{
			groundedPlayer = controller.isGrounded;
			if (groundedPlayer && playerVelocity.y < 0)
			{
				playerVelocity.y = 0f;
			}
			Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
			Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
			controller.Move(move * Time.deltaTime * playerSpeed);

			if (move != Vector3.zero)
			{
			_anim.SetBool("Trigger", true);
			gameObject.transform.forward = move;
			}
			else
			{
			_anim.SetBool("Trigger", false);
		}
			playerVelocity.y += gravityValue * Time.deltaTime;
			controller.Move(playerVelocity * Time.deltaTime);
	}
}

