using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestInformation : MonoBehaviour
{
	#region public ����
	public string name;  //�̸�
	public int number; //���̾� �� ���Ŀ� �ʿ��� ��ȣ
	public float speed; //�ӵ�
	public bool check; //������ �ް� �ִ��� üũ
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
