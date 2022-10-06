using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	Vector2 difference = Vector2.zero; //���콺 ��ġ ������ �Ÿ��� ��Ÿ���� ����
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

	//�ӽ�
	bool isMoneyClick;
	public bool MoneyClick
	{
		get { return isMoneyClick; }
		set { isMoneyClick = value; }
	}

	////���콺�� Ŭ������ �� ��ü�� ������ ���Ѵ�.
	private void OnMouseDown()
	{
		//���콺�� ���� ��ġ - �ش� ��ü�� ��ġ
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

	//���̻� ��ü�� ����Ű�� ���� �� (��Ŭ�� �� ��)
	private void OnMouseExit()
	{
		isClick = false;
		isDrag = false;
	}
}
