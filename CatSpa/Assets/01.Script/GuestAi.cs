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
	bool isWaiting;     //대기
	bool isMassage;		//마사지 받고 있는지

	Drag isDrag;

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

	void MassageEnd()
	{
		BubbleUi(false);
		ani.SetBool("Walk", false);
	}

	void Massage()
	{
		isMassage = true;
		ani.SetBool("Walk", true);
		BubbleUi(true);
	}

	void BubbleUi(bool setActive)
	{
		bubbleUi.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		SkillManager.Instance.Skill_Select(new Vector2(transform.position.x + 0.52f, transform.position.y + 0.52f));

		bubbleUi.SetActive(setActive);
	}

	void LayDown()
	{
		Massage();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Mat"))
		{
			isWaiting = true;
			Invoke("LayDown", 0.5f);
		}

		else if (collision.gameObject.tag == "Guest")
			isWalk = false;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Guest")
			isWalk = true;
	}
}

