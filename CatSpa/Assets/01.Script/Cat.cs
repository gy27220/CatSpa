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

	public void Start()
	{
		ani = GetComponent<Animator>();
	}


	void Update()
	{
		//임시 
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Debug.Log("일하기");
			ani.SetBool("Working", true);
		}

		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			Debug.Log("휴식");
			ani.SetBool("Working", false);
		}
	}
}
