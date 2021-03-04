using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D.Examples;
using UnityEngine.UI;

public class PaintCount : MonoBehaviour
{
	[SerializeField] Text _text;
	P3dChangeCounter _counter;
	int _iValue;
	float i;
	private void Awake()
	{
		_counter = GetComponent<P3dChangeCounter>();
	}
	private void Update()
	{
		i = _counter.Ratio * 100;
		_iValue = 100-(int)i;
		_text.text =_iValue.ToString()+"%";
	}
}
