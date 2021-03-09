using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D.Examples;
using UnityEngine.UI;

public class PaintCount : MonoBehaviour
{
	[SerializeField] P3dChangeCounter _counter ;
	[SerializeField] Image _fillImage;
	[SerializeField] GameObject _levelComplete;
	[SerializeField] Text _rankText;

	RankingSystem _rank;
	Text _text;
	int _iValue;
	float _fillValue;
	float i;
	private void Awake()
	{
		_text = GetComponentInChildren<Text>();
		_rank = FindObjectOfType<RankingSystem>();
	}
	private void Update()
	{
		i = _counter.Ratio * 100;
		_iValue = 100-(int)i;
		_fillValue = (100 - i)/100;
		_text.text =_iValue.ToString()+"%";
		_fillImage.fillAmount =_fillValue;
		_rankText.text = _rank._currentRank+".";
		if (_fillValue>=1)
		{
			_levelComplete.SetActive(true);
		}
	}
}
