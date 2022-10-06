using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldText : MonoBehaviour
{
	public static GoldText instance;
	TextMeshProUGUI textMeshP;
	public int goldText;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		textMeshP = GetComponent<TextMeshProUGUI>();
		goldText = 0;
	}


	public void setMoney(int gold)
	{
		goldText += gold;
		textMeshP.text = goldText.ToString();
	}
}
