using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAi : MonoBehaviour
{
	public GameObject bubbleUi;

	Vector2 pos;
	float Speed = 2f;
	Animator ani;

	bool isWalk;

	//
	//public GameObject selectOil;

	//GameObject oil;

	Vector2 objPos;
	public Vector2 Position
	{
		set { objPos = value; }
	}

	void Start()
    {
		isWalk = true;
		pos = transform.position;
		ani = GetComponent<Animator>();

		//oil = selectOil.GetComponent<RandomSelect>().Random_Select_Oil();
	}

    void Update()
    {
		//if (isWalk)
		//Move(new Vector2(-1.5f, -1.4f));
		// Move(new Vector2(objPos.x, objPos.y));

		//else
		// massageEnd();

		if(!isWalk)
		{
			ani.SetBool("Walk", true);
			BubbleUi(true);
		}
	}

	void Move(Vector2 matPos)
	{
		pos = Vector2.MoveTowards(pos, matPos, Speed * Time.deltaTime);
		transform.position = pos;

		//목표 지점에 도착
		if (matPos == pos)
		{
			ani.SetBool("Walk", true);
			BubbleUi(true);
		}
	}

	void MassageEnd()
	{
		Move(new Vector2(0.95f, 3f));
		BubbleUi(false);
		ani.SetBool("Walk", false);
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
		isWalk = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Mat"))
		{
			Invoke("LayDown", 0.5f);
		}
	}
}