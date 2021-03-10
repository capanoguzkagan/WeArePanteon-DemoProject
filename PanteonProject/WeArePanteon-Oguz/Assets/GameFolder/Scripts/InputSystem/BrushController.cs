using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D.Examples;

public class BrushController : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 2.0f;
	private Player playerInput;
	private CharacterController controller;
	

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
			Vector3 moving = new Vector3(0f, 0f, 0.2f);
			controller.Move(move * Time.deltaTime * playerSpeed);
	
			if (Input.GetMouseButtonDown(0))
			{
			controller.Move(moving);
			}
			if (Input.GetMouseButtonUp(0))
			{
			controller.Move((-1)*moving);
		}
	}
	
}

