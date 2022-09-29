using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	Vector2 difference = Vector2.zero; //마우스 위치 사이의 거리를 나타내는 벡터

	//마우스를 클릭했을 때
	private void OnMouseDown()
	{
		//마우스의 월드 위치 - 해당 객체의 위치
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
//	Debug.Log("마우스 클릭 ");
//	DefaultPos = this.transform.position;
//}

//private void OnMouseUp()
//{
//	Debug.Log("마우스 뗌");
//}

//private void OnMouseDrag()
//{
//	Debug.Log("드래그중");

//	DefaultPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
//	this.transform.position = Camera.main.ScreenToWorldPoint(DefaultPos);

//}
