using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestInformation : MonoBehaviour
{
	#region public 변수
	public string name;  //이름
	public int number; //레이어 및 정렬에 필요한 번호
	public float speed; //속도
	public bool check; //마사지 받고 있는지 체크
	#endregion

	public string Name
	{
		get { return name; }
	}

	public int Number
	{
		get { return number; }
		set { number = value; }
	}

	public float Speed
	{
		get{return speed;}

		set{speed = value;}
	}

	public bool Check
	{
		get { return check; }
		set { check = value; }
	}
}
