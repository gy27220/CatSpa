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


	private void Start()
	{
		onEnableCat = false;
	}

	private void Update()
	{
		catCheck();
	}

	GameObject SitDownCheck()
	{
		//누워있고 클릭한 게스트의 정보를 넘겨준다.
		for (int i = 0; i < guest.objectList.Count; ++i)
		{
			//손님이 누워있고
			if (guest.objectList[i].GetComponent<GuestAi>().Wait)
			{
				//누워있는 사람중 클릭한 사람만
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


	void catCheck()
	{
		for (int i = 0; i < cat.objectList.Count; ++i)
		{
			if (!cat.objectList[i].GetComponent<Cat>().Work)
			{
				if(onEnableCat)
				cat.objectList[i].SetActive(true);

				cat.objectList[i].GetComponent<Cat>().Obj = SitDownCheck();
			}
		}
	}
}
