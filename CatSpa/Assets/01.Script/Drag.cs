using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	Vector2 difference = Vector2.zero; //���콺 ��ġ ������ �Ÿ��� ��Ÿ���� ����

	bool isDrag; 
	public bool DragCheck
	{
		get { return isDrag; }
		set { isDrag = value; }
	}

	private void Start()
	{
		isDrag = false;
	}


	//���콺�� Ŭ������ ��
	private void OnMouseDown()
	{
		Debug.Log("Ŭ��");
		//���콺�� ���� ��ġ - �ش� ��ü�� ��ġ
		difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
	}

	private void OnMouseDrag()
	{
		isDrag = true;
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
	}

	private void OnMouseUp()
	{
		isDrag = false;
	}
}
