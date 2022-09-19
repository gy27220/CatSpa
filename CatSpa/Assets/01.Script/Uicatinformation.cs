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
		//��ư�� Ŭ������ �� �ش� ��ư�� �����ִ� ����(�ڽĵ��� ��������)�� �ѱ��.
		name = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
		Image = gameObject.GetComponentsInChildren<Image>()[objectNumber].sprite;

		Debug.Log(name);
		Debug.Log(Image.name);

		catInformation.SetActive(true);
	}

}
