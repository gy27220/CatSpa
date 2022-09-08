using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
	#region public ����
	public string name;  //�̸�
	public float speed; //�ӵ�
	public bool   check; //������ �ް� �ִ��� üũ
	#endregion


	string favorite_Skill; //�����ϴ� ��ų?
	int	   money;          //������
	Vector2 pos;
	Vector2 target; //��ǥ ����


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
