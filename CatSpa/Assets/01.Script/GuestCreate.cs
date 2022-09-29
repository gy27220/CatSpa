using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCreate : MonoBehaviour
{
	#region public 변수
	public GameObject[] guestPrafeb; // 프리팹들
	#endregion

	[HideInInspector]
	public List<GameObject> guestList; //프리팹을 저장할 리스트

	//private
	int listCountMin;  //리스트의 최소값
	int listCountMax;  //리스트의 최대값

	void Start()
	{
		listCountMin = 0;
		listCountMax = 7;

		//오브젝트 풀링
		for (int i = 0; i < listCountMax; ++i)
		{
			//종류별로 리스트 안에 넣는다.
			guestList.Add(Instantiate(guestPrafeb[Random.Range(0, 2)]));
			guestList[i].SetActive(false);
		}

		StartCoroutine("Enable_Object");
	}

	IEnumerator Enable_Object()
	{
		yield return new WaitForSeconds(1f);

		guestList[listCountMin++].SetActive(true);

		if (listCountMin == listCountMax)
			listCountMin = 0;

		//재귀로 계속 초마다 호출
		StartCoroutine("Enable_Object");
	}
}
