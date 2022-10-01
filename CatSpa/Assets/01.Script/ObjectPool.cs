using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	#region enum 
	public enum CREATE_TYPE { CT_GUEST, CT_CAT, CT_END };
	public CREATE_TYPE type;
	#endregion

	#region public ����
	public GameObject[] objectPrefab; // ������
	#endregion

	[HideInInspector]
	public List<GameObject> objectList; //�������� ������ ����Ʈ


	//private
	int listCountMin;  //����Ʈ�� �ּҰ�
	int listCountMax;  //����Ʈ�� �ִ밪

	private void Start()
	{
		listCountMin = 0;
		listCountMax = objectPrefab.Length;

		ObjectCreate();
	}

	void ObjectCreate()
	{
		switch (type)
		{
			case CREATE_TYPE.CT_GUEST:
				for (int i = 0; i < objectPrefab.Length; ++i)
				{
					objectList.Add(Instantiate(objectPrefab[Random.Range(0, 3)]));
					objectList[i].SetActive(false);
					LayerSort(i);
				}

				StartCoroutine("Enable_Object");
				break;

			case CREATE_TYPE.CT_CAT:
				for (int i = 0; i < objectPrefab.Length; ++i)
					objectList.Add(Instantiate(objectPrefab[i]));
				break;
		}
	}

	void LayerSort(int index)
	{
		if (index != 0)
		{
			objectList[index].GetComponent<SpriteRenderer>().sortingOrder =
			objectList[index - 1].GetComponent<SpriteRenderer>().sortingOrder - 1;
		}
	}



	IEnumerator Enable_Object()
	{
		yield return new WaitForSeconds(1f);

		objectList[listCountMin++].SetActive(true);

		if (listCountMin == listCountMax)
			listCountMin = 0;

		//��ͷ� ��� �ʸ��� ȣ��
		StartCoroutine("Enable_Object");
	}
}
