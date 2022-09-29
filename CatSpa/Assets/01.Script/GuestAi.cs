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

	Drag isDrag;
	//public GameObject selectOil;
	//GameObject oil;

	void Start()
	{
		pos = transform.position;

		isWalk = true;
		isWaiting = false;
		ani = GetComponent<Animator>();
		spRender = GetComponent<SpriteRenderer>();
		isDrag = GetComponent<Drag>();
		//oil = selectOil.GetComponent<RandomSelect>().Random_Select_Oil();
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
		ani.SetBool("Walk", true);
		BubbleUi(true);
	}

	void BubbleUi(bool setActive)
	{
		bubbleUi.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		//oil.transform.position = new Vector2(pos.x + 0.52f, pos.y + 0.52f);
		//oil.SetActive(setActive);
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

