using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cat : MonoBehaviour
{
	#region public ����
	public string name;
	public string introduce;
	public Texture2D image;
	#endregion

	#region ������Ƽ
	public string Name
	{
		get { return name; }
	}

	public string Introduce
	{
		get { return introduce; }
	}

	public Texture2D Image
	{
		get { return image; }
	}
	#endregion

	private Animator ani;


	float workingTime; //���ϴ� �ð�
	GameObject obj; //�մ�
	public GameObject Obj
	{
		get { return obj; }
		set { obj = value; }
	}

	//�ӽ�
	//���� �ϰ��ִ��� ���ϰ��ִ��� üũ
	public bool work;
	public bool Work
	{
		get { return work; }
		set { work = value; }
	}

	public void Start()
	{
		work = false;
		workingTime = 0;
		ani = GetComponent<Animator>();
	}


	void Update()
	{
		if (obj == null)
			return;
		else
			work = true;


		Working();

		Debug.Log(workingTime);
	}

	void Working()
	{
		if (work && workingTime == 0)
		{
			workingTime = obj.GetComponent<GuestAi>().Oil.GetComponent<SkillInformation>().Time;
		}

		//���� ���񽺽ð�����
		if (workingTime > 0)
		{
			//�մ� ��ġ�� �̵��Ѵ�.
			transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y);

			ani.SetBool("Working", true);
			workingTime -= Time.deltaTime;
		}
		else
		{
			work = false;
			this.gameObject.SetActive(false);
			transform.position = new Vector2(-10f, -10f);
			workingTime = 0;
		}
	}

	void Resting()
	{
		Debug.Log("�޽�");
		ani.SetBool("Working", false);
	}
}
