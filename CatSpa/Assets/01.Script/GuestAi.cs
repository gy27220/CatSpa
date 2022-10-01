using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAi : MonoBehaviour
{
	#region public 변수
	public GameObject target;
	public GameObject bubbleUi;
	public float Speed = 2f;
	#endregion

	//private


	Animator ani;
	SpriteRenderer spRender;
	Vector2 pos;
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
		//직원에게 전달해주기위함
		get { return oil; }
	}

	void Start()
	{
		pos = transform.position;
		isWalk = true;
		isWaiting = false;
		isMassage = false;
		ani = GetComponent<Animator>();
		spRender = GetComponent<SpriteRenderer>();
		isDrag = GetComponent<Drag>();
	}

	void Update()
	{
		//걷는 중 && 드래그중아님 && 기다리지도않음
		if(isWalk && !isDrag.DragCheck && !isWaiting)
			Move(target.transform.position);

		if(isDrag.DragCheck)
			spRender.sortingOrder = 3;
	}

	void Move(Vector2 target)
	{
		pos = Vector2.MoveTowards(pos, target, Speed * Time.deltaTime);
		transform.position = pos;
	}

	void BubbleUi(bool setActive)
	{
		bubbleUi.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		oil = SkillManager.Instance.Skill_Random_Instantiate();
		SkillManager.Instance.Skill_Select(transform.position);
		bubbleUi.SetActive(setActive);
	}

	//마사지 받을 준비
	void LayDown()
	{
		ani.SetBool("Walk", true);

		//마사지를 시작하면
		if (!isMassage)
			BubbleUi(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//누웠는지 체크
		if (collision.gameObject.CompareTag("Mat"))
		{
			Vector2 matPos = collision.gameObject.transform.position;

			transform.position = new Vector2(matPos.x, matPos.y);

			isWaiting = true;
			Invoke("LayDown", 0.5f);
		}

		//손님끼리 충돌했으면 멈추고 줄서라
		else if (collision.gameObject.tag == "Guest")
			isWalk = false;
	
		else if (collision.gameObject.tag == "Cat")
			isMassage = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Guest")
			isWalk = true;
	}
}

