using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAi : MonoBehaviour
{
	#region public ����
	public GameObject target;
	public GameObject bubbleUi;
	public GameObject goldPrafeb;
	public float Speed = 2f;
	#endregion

	//private
	BoxCollider2D boxColl;
	Animator ani;
	SpriteRenderer spRender;
	Vector2 pos;
	Vector2 matPos;

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

	bool serviceEnd;
	int price;

	GameObject gold;

	void Start()
	{
		oil = SkillManager.Instance.Skill_Random_Instantiate();
		price = oil.GetComponent<SkillInformation>().Price;
		gold = Instantiate(goldPrafeb);
		pos = transform.position;
		isWalk = true;
		isWaiting = false;
		isMassage = false;
		serviceEnd = false;
		boxColl = GetComponent<BoxCollider2D>();
		ani = GetComponent<Animator>();
		spRender = GetComponent<SpriteRenderer>();
		isDrag = GetComponent<Drag>();
	}

	void Update()
	{
		//�ȴ� �� && �巡���߾ƴ� && ��ٸ���������
		if (isWalk && !isDrag.DragCheck && !isWaiting)
			Move(target.transform.position);

		if (isDrag.DragCheck)
			spRender.sortingOrder = 3;

		//���������϶� ui��ġ �� ������ ����
		if (isMassage)
		{
			oil.transform.localScale = new Vector2(0.4f, 0.4f);
			oil.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f);
		}

		//���� ������
		if(serviceEnd)
		{
			oil.SetActive(false);
			ani.SetBool("Walk", false);
			boxColl.enabled = false;

			if(gold != null)
			Create_Money();

			Invoke("Moving", 0.1f);
		}

		pos = transform.position;
	}

	void Create_Money()
	{
		gold.transform.position = new Vector2(matPos.x, matPos.y - 0.7f);
		gold.GetComponent<Gold>().gold = price;
		//Debug.Log(gold.GetComponent<Gold>().gold);
		gold.SetActive(true);
	}

	void Move(Vector2 target)
	{
		pos = Vector2.MoveTowards(pos, target, Speed * Time.deltaTime);
		transform.position = pos;
	}

	void Moving()
	{
		Vector2 targetPos = new Vector2(-1f, 7f);
		transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);

		if(targetPos == pos)
			serviceEnd = false;
	}

	void ServiceUi(bool setActive)
	{
		oil.SetActive(true);
		oil.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		bubbleUi.SetActive(setActive);
		bubbleUi.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
		
	}

	//������ ���� �غ�
	void LayDown()
	{
		ani.SetBool("Walk", true);
		ServiceUi(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//�������� üũ
		if (collision.gameObject.CompareTag("Mat"))
		{
			matPos = collision.gameObject.transform.position;

			transform.position = new Vector2(matPos.x, matPos.y);

			isWaiting = true;
			Invoke("LayDown", 0.5f);
		}

		//�մԳ��� �浹������ ���߰� �ټ���
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

		else if (collision.gameObject.tag == "Cat")
		{
			isMassage = false;
			serviceEnd = true;
		}
	}
}

