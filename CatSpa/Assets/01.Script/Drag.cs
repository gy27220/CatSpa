using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	Vector2 difference = Vector2.zero; //���콺 ��ġ ������ �Ÿ��� ��Ÿ���� ����

	//���콺�� Ŭ������ ��
	private void OnMouseDown()
	{
		//���콺�� ���� ��ġ - �ش� ��ü�� ��ġ
		difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
	}

	private void OnMouseDrag()
	{
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
	}
}

//public static Vector3 DefaultPos;


//private void OnMouseDown()
//{
//	Debug.Log("���콺 Ŭ�� ");
//	DefaultPos = this.transform.position;
//}

//private void OnMouseUp()
//{
//	Debug.Log("���콺 ��");
//}

//private void OnMouseDrag()
//{
//	Debug.Log("�巡����");

//	DefaultPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
//	this.transform.position = Camera.main.ScreenToWorldPoint(DefaultPos);

//}
