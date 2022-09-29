using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCreate : MonoBehaviour
{
	#region public ����
	public GameObject[] guestPrafeb; // �����յ�
	#endregion

	[HideInInspector]
	public List<GameObject> guestList; //�������� ������ ����Ʈ

	//private
	int listCountMin;  //����Ʈ�� �ּҰ�
	int listCountMax;  //����Ʈ�� �ִ밪

	void Start()
	{
		listCountMin = 0;
		listCountMax = 7;

		//������Ʈ Ǯ��
		for (int i = 0; i < listCountMax; ++i)
		{
			//�������� ����Ʈ �ȿ� �ִ´�.
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

		//��ͷ� ��� �ʸ��� ȣ��
		StartCoroutine("Enable_Object");
	}
}
