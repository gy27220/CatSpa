using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
	#region public 변수
	public string name;  //이름
	public float speed; //속도
	public bool   check; //마사지 받고 있는지 체크
	#endregion


	string favorite_Skill; //좋아하는 스킬?
	int	   money;          //소지금
	Vector2 pos;
	Vector2 target; //목표 지점


	private void OnEnable()
	{
		StartCoroutine("Disable_Object");
	}

	void Start()
    {
		pos = transform.position;
		target = new Vector2(pos.x, 1.4f);

		StartCoroutine("Disable_Object");   
    }

 
    void Update()
    {
		Move();

	}

	void Move()
	{
		pos = Vector2.Lerp(pos, target, speed * Time.deltaTime);

		transform.position = pos;
	}

	IEnumerator Disable_Object()
	{
		yield return new WaitForSeconds(10f);
		gameObject.SetActive(false);
	}
}
