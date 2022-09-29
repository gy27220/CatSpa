using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
	GuestInformation guestObj;

	string favorite_Skill; //좋아하는 스킬?
	int	   money;          //소지금
	Vector2 pos;
	Vector2 target; //목표 지점
	Vector2 rayPos;
	bool createObj;


	public Vector2 RayPos
	{
		get { return rayPos; }
	}

	public bool CreateObj
	{
		get { return createObj; }
		set { createObj = value; }
	}


	public Vector2 Target
	{
		get { return target; }
		set { target = value; }
	}

	private void OnEnable()
	{
		createObj = true;
		StartCoroutine("Disable_Object");
	}

	void Start()
    {
		guestObj = GetComponent<GuestInformation>();
		pos = transform.position;

		target = new Vector2(pos.x, 1.4f);

		StartCoroutine("Disable_Object");

	}

 
    void Update()
    {
		rayPos = new Vector2(pos.x, pos.y - 0.3f);
		//Debug.DrawRay(rayPos, Vector2.down * 0.4f, new Color(1, 0, 0));

		Move();
	}

	void Move()
	{
		pos = Vector2.MoveTowards(pos, target, guestObj.Speed * Time.deltaTime);
		transform.position = pos;
	}



	IEnumerator Disable_Object()
	{
		yield return new WaitForSeconds(10f);
		gameObject.SetActive(false);
		pos = new Vector2(-0.95f, 4.65f);
		createObj = false;
	}
}

