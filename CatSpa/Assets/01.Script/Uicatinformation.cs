using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Uicatinformation : MouseClick
{
	const int objectNumber = 1;

	public GameObject catInformation;

	string name;
	Sprite Image;

	public void ButtonClick()
	{
		//버튼을 클릭했을 때 해당 버튼이 갖고있는 정보(자식들이 갖고있음)를 넘긴다.
		name = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
		Image = gameObject.GetComponentsInChildren<Image>()[objectNumber].sprite;

		Debug.Log(name);
		Debug.Log(Image.name);

		catInformation.SetActive(true);
	}

}
