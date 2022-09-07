using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCreate : MonoBehaviour
{
	#region public 변수
	public GameObject[] guest;
	#endregion

	[HideInInspector]
	public GameObject[] obj;

	//예시 스킬 랜덤추출하기위함
	string[] skillType = new string[3];

	//private
	int countMax;
	int countMin;

	void Start()
	{
		skillType[0] = "아로마 오일";
		skillType[1] = "돌 찜질";
		skillType[2] = "오이 팩";

		countMax = 10;
		countMin = 0;
		obj = new GameObject[countMax];

		for (int i = 0; i < countMax; ++i)
		{
			obj[i] = Instantiate(guest[Random.Range(0, guest.Length)]);
			obj[i].SetActive(false);
		}

		StartCoroutine("Enable_Object");
	}

	IEnumerator Enable_Object()
	{
		yield return new WaitForSeconds(3f);
		Debug.LogFormat("타입 : {0}", skillType[Random.Range(0, skillType.Length)]);
		obj[countMin++].SetActive(true);

		if (countMin == countMax)
			countMin = 0;

		StartCoroutine("Enable_Object");
	}
}
