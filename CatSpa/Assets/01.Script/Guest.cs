using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
	public enum STATE { IDLE, MOVE, LAYDOWN, GETUP, LEAVE };

	#region public ����
	public GameObject target;
	public GameObject bubbleUi;
	public float speed = 2f;
	#endregion

	//private
	Animator ani;
	SpriteRenderer spRender;
	Vector2 pos;
	STATE state = STATE.MOVE;

	bool isWalk;        //�̵�
	bool isMassage;     //������ �ް� �ִ���
	bool isWaiting;     //���
	public bool Wait
	{
		get { return isWaiting; }
		set { isWaiting = value; }
	}

	Drag isDrag;
	GameObject oil; //������ ������ ����
	public GameObject Oil
	{
		get { return oil; }
	}

	private void Start()
	{
		oil = SkillManager.Instance.Skill_Random_Instantiate();
		pos = transform.position;
		isWalk = true;
		isWaiting = false;
		isMassage = false;
		ani = GetComponent<Animator>();
		spRender = GetComponent<SpriteRenderer>();
		isDrag = GetComponent<Drag>();
	}


	private void Update()
	{


		switch(state)
		{
			case STATE.IDLE:
				//�ٸ� �մ��� �������� �� ��� (�ټ���)
				break;

			case STATE.LAYDOWN:
				//�ڸ��� ����
				break;

			case STATE.GETUP:
				//�Ͼ�� 
				break;

			case STATE.LEAVE:
				//������
				break;
		}
	}


	void Move(Vector2 pos)
	{
		transform.position = Vector2.MoveTowards(pos, pos, speed * Time.deltaTime);
	}
}

/*
 private void OnEnable()
	{	
		StartCoroutine("Disable_Object");
	}

	void Start()
    {	
		StartCoroutine("Disable_Object");
	}


	IEnumerator Disable_Object()
	{
		yield return new WaitForSeconds(10f);
	
	}
	 
	 
	 */
