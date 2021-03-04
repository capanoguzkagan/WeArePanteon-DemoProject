using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 2.0f;
	private Player playerInput;
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float gravityValue = 0;

	private void Awake()
	{
		playerInput = new Player();
		controller = GetComponent<CharacterController>();

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
			Vector3 move = new Vector3(movementInput.x, movementInput.y, 0f);
			controller.Move(move * Time.deltaTime * playerSpeed);

			if (move != Vector3.zero)
			{
			//gameObject.transform.forward = move;
			}
	}
	
}

