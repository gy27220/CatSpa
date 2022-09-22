using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex : MonoBehaviour
{
	public GameObject bubbleUi;

	Vector2 pos;
	float Speed = 2f;
	Animator ani;

	bool isWalk;

	void Start()
    {
		isWalk = true;
		pos = transform.position;
		ani = GetComponent<Animator>();
	}

    void Update()
    {
		if(isWalk)
		 Move(new Vector2(-1.5f, -1.4f));

		else
		 massageEnd();

		//�ӽ�
		if (Input.GetKeyDown(KeyCode.A))
			isWalk = false;
	}

	void Move(Vector2 matPos)
	{
		pos = Vector2.MoveTowards(pos, matPos, Speed * Time.deltaTime);
		transform.position = pos;

		//��ǥ ������ ����
		if (matPos == pos)
		{
			ani.SetBool("Walk", true);
			BubbleUi(true);
		}
	}

	void massageEnd()
	{
		Move(new Vector2(0.95f, 3f));
		BubbleUi(false);
		ani.SetBool("Walk", false);
	}

	void BubbleUi(bool setActive)
	{
		bubbleUi.transform.position = new Vector2(pos.x + 0.5f, pos.y + 0.5f);
		bubbleUi.SetActive(setActive);
	}

}