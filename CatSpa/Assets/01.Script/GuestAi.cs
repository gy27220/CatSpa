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
		//�������� �������ֱ�����
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

	void BubbleUi(bool setActive)
	{
		bubbleUi.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		oil = SkillManager.Instance.Skill_Random_Instantiate();
		SkillManager.Instance.Skill_Select(transform.position);
		bubbleUi.SetActive(setActive);
	}

	//������ ���� �غ�
	void LayDown()
	{
		ani.SetBool("Walk", true);

		//�������� �����ϸ�
		if (!isMassage)
			BubbleUi(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//�������� üũ
		if (collision.gameObject.CompareTag("Mat"))
		{
			Vector2 matPos = collision.gameObject.transform.position;

			transform.position = new Vector2(matPos.x, matPos.y);

			isWaiting = true;
			Invoke("LayDown", 0.5f);
		}

		//�մԳ��� �浹������ ���߰� �ټ���
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

