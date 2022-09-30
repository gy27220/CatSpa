using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAi : MonoBehaviour
{
	#region public ����
	public GameObject target;
	public GameObject bubbleUi;
	public float Speed = 2f;
	#endregion

	//private


	Animator ani;
	SpriteRenderer spRender;
	Vector2 pos;
	bool isWalk;        //�̵�
	bool isWaiting;     //���
	bool isMassage;		//������ �ް� �ִ���

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
		//�ȴ� �� && �巡���߾ƴ� && ��ٸ���������
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

