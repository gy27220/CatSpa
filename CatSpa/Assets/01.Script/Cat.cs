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

	public void Start()
	{
		ani = GetComponent<Animator>();
	}


	void Update()
	{
		//�ӽ� 
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Debug.Log("���ϱ�");
			ani.SetBool("Working", true);
		}

		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			Debug.Log("�޽�");
			ani.SetBool("Working", false);
		}
	}
}
