using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
	#region public ����
	public string name;  //�̸�
	public bool   check; //������ �ް� �ִ��� üũ
	#endregion


	string favorite_Skill; //�����ϴ� ��ų?
	int	   money;          //������


	private void OnEnable()
	{
		StartCoroutine("Disable_Object");
	}

	void Start()
    {
		StartCoroutine("Disable_Object");   
    }

 
    void Update()
    {
        
    }

	IEnumerator Disable_Object()
	{
		yield return new WaitForSeconds(4f);
		gameObject.SetActive(false);
	}
}
