using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public ObjectPool guest;
	public ObjectPool cat;

	GameObject catObj;
	GameObject guestObj;

	bool onEnableCat;

	int catCount;

	private void Start()
	{
		catCount = 0;
		onEnableCat = false;
	}

	private void Update()
	{
		Cat_Work_Check();
	}

	GameObject SitDownCheck()
	{
		//�����ְ� Ŭ���� �Խ�Ʈ�� ������ �Ѱ��ش�.
		for (int i = 0; i < guest.objectList.Count; ++i)
		{
			if (guest.objectList[i].GetComponent<GuestAi>().Wait)
			{
				//�����ִ� ����� Ŭ���� �����
				if (guest.objectList[i].GetComponent<Drag>().Click &&
					!guest.objectList[i].GetComponent<Drag>().DragCheck)
				{
					onEnableCat = true;
					guestObj = guest.objectList[i];

					return guestObj;
				}
				else
					onEnableCat = false;
			}
		}
		return guestObj;
	}

	void Cat_Work_Check()
	{
		if (catCount >= cat.objectList.Count)
			catCount = 0;

		for (; catCount < cat.objectList.Count;)
		{
			if (!cat.objectList[catCount].GetComponent<Cat>().Work)
			{
				catObj = cat.objectList[catCount];
				catObj.GetComponent<Cat>().Obj = SitDownCheck();

				if (onEnableCat)
					catObj.SetActive(true);
			}
			else
				++catCount;

			return;
		}
	}
}
