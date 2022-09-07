using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCreate : MonoBehaviour
{
	#region public ����
	public GameObject[] guest;
	#endregion

	[HideInInspector]
	public GameObject[] obj;

	//���� ��ų ���������ϱ�����
	string[] skillType = new string[3];

	//private
	int countMax;
	int countMin;

	void Start()
	{
		skillType[0] = "�Ʒθ� ����";
		skillType[1] = "�� ����";
		skillType[2] = "���� ��";

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
		Debug.LogFormat("Ÿ�� : {0}", skillType[Random.Range(0, skillType.Length)]);
		obj[countMin++].SetActive(true);

		if (countMin == countMax)
			countMin = 0;

		StartCoroutine("Enable_Object");
	}
}
