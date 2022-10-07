using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
	public enum STATE { IDLE, MOVE, LAYDOWN, GETUP, LEAVE };

	#region public 변수
	public GameObject target;
	public GameObject bubbleUi;
	public float speed = 2f;
	#endregion

	//private
	Animator ani;
	SpriteRenderer spRender;
	Vector2 pos;
	STATE state = STATE.MOVE;

	bool isWalk;        //이동
	bool isMassage;     //마사지 받고 있는지
	bool isWaiting;     //대기
	public bool Wait
	{
		get { return isWaiting; }
		set { isWaiting = value; }
	}

	Drag isDrag;
	GameObject oil; //선택한 오일의 정보
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
				//다른 손님을 마주쳤을 때 대기 (줄서기)
				break;

			case STATE.LAYDOWN:
				//자리에 눕기
				break;

			case STATE.GETUP:
				//일어나기 
				break;

			case STATE.LEAVE:
				//나가기
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
