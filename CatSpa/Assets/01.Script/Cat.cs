using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cat : MonoBehaviour
{
	#region public 변수
	public string name;
	public string introduce;
	public Texture2D image;
	#endregion

	#region 프로퍼티
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


	float workingTime; //일하는 시간
	GameObject obj; //손님
	public GameObject Obj
	{
		get { return obj; }
		set { obj = value; }
	}

	//임시
	//일을 하고있는지 안하고있는지 체크
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

		//오일 서비스시간까지
		if (workingTime > 0)
		{
			//손님 위치로 이동한다.
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
		Debug.Log("휴식");
		ani.SetBool("Working", false);
	}
}
