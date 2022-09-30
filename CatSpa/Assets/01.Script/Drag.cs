using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	Vector2 difference = Vector2.zero; //마우스 위치 사이의 거리를 나타내는 벡터

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


	//마우스를 클릭했을 때
	private void OnMouseDown()
	{
		Debug.Log("클릭");
		//마우스의 월드 위치 - 해당 객체의 위치
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
