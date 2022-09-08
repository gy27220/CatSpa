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
	int asd = 0;

	//private
	int countMax;
	int countMin;

	int[] guestNum;

	Vector2 rayPos;
	int num;

	void Start()
	{
		skillType[0] = "아로마 오일";
		skillType[1] = "돌 찜질";
		skillType[2] = "오이 팩";

		num = 0;
		countMax = 10;
		countMin = 0;
		obj = new GameObject[countMax];
		guestNum = new int[countMax];

		for (int i = 0; i < countMax; ++i)
		{
			obj[i] = Instantiate(guest[Random.Range(0, guest.Length)]);
			guestNum[i] = obj[i].GetComponent<GuestInformation>().Number = i;
			obj[i].GetComponent<Guest>().CreateObj = false;
			obj[i].SetActive(false);
		}
		StartCoroutine("Enable_Object");
	}

	private void Update()
	{
		LayerSetting();
		Object_LineUp();
	}

	//생성 시 정렬
	void Object_LineUp()
	{
		for (int i = 0; i < countMax; ++i)
		{
			Vector2 pos = new Vector2(obj[i].GetComponent<Guest>().transform.position.x, 0);
			RaycastHit2D hit = Physics2D.Raycast(obj[i].GetComponent<Guest>().RayPos,Vector2.down * 0.3f);

			if (hit.collider == null)
			{
				obj[i].GetComponent<Guest>().Target = new Vector2(-0.95f, 1.4f);
			}

			else
			{
				pos.y = hit.collider.transform.position.y + 0.5f;
				obj[i].GetComponent<Guest>().Target = pos;
			}
		}
	}

	void LayerSetting()
	{
		for (int i = 0; i < countMax; ++i)
		{
			Vector2 pos = new Vector2(obj[i].GetComponent<Guest>().transform.position.x, 0);
			RaycastHit2D hit = Physics2D.Raycast(obj[i].GetComponent<Guest>().RayPos, Vector2.down * 0.3f);

			if (hit.collider != null)
				obj[i].GetComponent<SpriteRenderer>().sortingOrder = hit.collider.GetComponent<SpriteRenderer>().sortingOrder - 1;

			else
				obj[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
		}
	}

	IEnumerator Enable_Object()
	{
		yield return new WaitForSeconds(3f);
		//Debug.LogFormat("타입 : {0}", skillType[Random.Range(0, skillType.Length)]);
		obj[num++].GetComponent<Guest>().CreateObj = true;
		obj[countMin++].SetActive(true);


		if (countMin == countMax)
		{
			countMin = 0;
			num = 0;
		}

		StartCoroutine("Enable_Object");
	}
}
