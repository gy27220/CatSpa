using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	Vector2 difference = Vector2.zero; //마우스 위치 사이의 거리를 나타내는 벡터
	Vector2 pos;
	GameObject obj;
	GuestAi guest;

	bool isDrag; 
	public bool DragCheck
	{
		get { return isDrag; }
		set { isDrag = value; }
	}

	bool isClick;
	public bool Click
	{
		get { return isClick; }
	}

	private void Start()
	{
		isDrag = false;
		isClick = false;
		isMoneyClick = false;

		guest = GetComponent<GuestAi>();
	}

	//임시
	bool isMoneyClick;
	public bool MoneyClick
	{
		get { return isMoneyClick; }
		set { isMoneyClick = value; }
	}

	////마우스를 클릭했을 때 객체의 정보를 구한다.
	private void OnMouseDown()
	{
		//마우스의 월드 위치 - 해당 객체의 위치
		difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

		RaycastHit2D hit = Physics2D.Raycast((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

		if(hit.collider != null)
			obj = hit.collider.gameObject;


		HitCheck(obj.tag);
	}

	private void OnMouseDrag()
	{
		if (obj.CompareTag("Guest") && !guest.Wait)
		{
			isDrag = true;
			transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
		}
	}

	void HitCheck(string name)
	{
		switch(name)
		{
			case "Guest":
				isClick = true;
				break;

			case "Money":
				isMoneyClick = true;
				break;
		}
	}

	//더이상 객체를 가르키지 않을 때 (재클릭 할 때)
	private void OnMouseExit()
	{
		isClick = false;
		isDrag = false;
	}
}
