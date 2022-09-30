using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Uicatinformation : MouseClick
{
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

		catInformation.SetActive(true);
	}

}
