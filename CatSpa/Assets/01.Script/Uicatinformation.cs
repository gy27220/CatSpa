using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Uicatinformation : MouseClick
{
	//const int objectNumber = 1;

	public GameObject catInformation;

	[Header ("List")]
	public Image list_Image;
	public TMPro.TextMeshProUGUI list_Name;

	[Header("Information")]
	public Image info_Image;
	public TMPro.TextMeshProUGUI info_Name;


	public void ButtonClick()
	{
		info_Image.sprite = list_Image.sprite;
		info_Name.text = list_Name.text;


		//버튼을 클릭했을 때 해당 버튼이 갖고있는 정보(자식들이 갖고있음)를 넘긴다.
		//name = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
		//Image = gameObject.GetComponentsInChildren<Image>()[objectNumber].sprite;
		//
		//Debug.Log(catInformation.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);

		//catInformation.GetComponentsInChildren<Image>()[2].sprite = Image;
		//catInformation.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text = name;
		//catInformation.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1].text = produce;

		catInformation.SetActive(true);
	}

}
