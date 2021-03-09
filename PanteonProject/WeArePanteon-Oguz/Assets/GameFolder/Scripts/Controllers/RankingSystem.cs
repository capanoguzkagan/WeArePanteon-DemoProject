using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingSystem : MonoBehaviour
{
	[SerializeField] GameObject[] _components;
	[SerializeField] GameObject _player;

	Text _rankText;
	int _currentRank;
	int _rankPlayer;

	private void Awake()
	{
		_rankText = GetComponentInChildren<Text>();
		_rankPlayer = 1;
		
	}
	void Update()
    {

			for (int i = 0; i < _components.Length; i++)
			{
				if (_components[i].transform.position.z-_player.transform.position.z>0)
				{
				_rankPlayer++;
				}
			}
		_currentRank = _rankPlayer;
		_rankText.text = _currentRank + ".";
		_rankPlayer = 1;
    }

}
