using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMovement : MonoBehaviour
{
	[SerializeField] float _objectSpeed = 4f;
	[SerializeField] Transform[] _positions;
	Transform _nextPos;
	int nextPosIndex;
	private void Awake()
	{
		_nextPos = _positions[0];
	}
	void Update()
	{
		MoveGameObject();
	}
	private void MoveGameObject()
	{
		if (transform.position==_nextPos.position)
		{
			nextPosIndex++;
			if (nextPosIndex>=_positions.Length)
			{
				nextPosIndex = 0;
			}
			_nextPos = _positions[nextPosIndex];
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, _nextPos.position, _objectSpeed * Time.deltaTime);
		}
	}
}
