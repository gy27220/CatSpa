using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInformation : MonoBehaviour
{
	//������Ʈ�� ���� �⺻���� Ư¡
	#region public ����
	public Texture2D image;
	public string name; 
	public string explanation; //�� ��ų�� ���� ����
	public int price; //����
	public float time; //���� �ð�
	#endregion

	public float Time
	{
		get { return time; }
	}

}
