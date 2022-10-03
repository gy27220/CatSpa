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
		get { return oil; }
	}

	void Start()
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

	void Update()
	{
		//걷는 중 && 드래그중아님 && 기다리지도않음
		if (isWalk && !isDrag.DragCheck && !isWaiting)
			Move(target.transform.position);

		if (isDrag.DragCheck)
			spRender.sortingOrder = 3;

		if (isMassage)
		{
			oil.transform.localScale = new Vector2(0.4f, 0.4f);
			oil.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f);
		}
	}

	void Move(Vector2 target)
	{
		pos = Vector2.MoveTowards(pos, target, Speed * Time.deltaTime);
		transform.position = pos;
	}

	void ServiceUi(bool setActive)
	{
		oil.SetActive(true);
		oil.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		bubbleUi.SetActive(setActive);
		bubbleUi.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);

	}

	//마사지 받을 준비
	void LayDown()
	{
		ani.SetBool("Walk", true);
		ServiceUi(true);
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
		{
			ServiceUi(false);
			isMassage = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Guest")
			isWalk = true;
	}
}

