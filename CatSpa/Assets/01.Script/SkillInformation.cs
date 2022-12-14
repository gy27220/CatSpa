using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInformation : MonoBehaviour
{
	//오브젝트가 갖는 기본적인 특징
	#region public 변수
	public Texture2D image;
	public string name; 
	public string explanation; //각 스킬에 대한 설명
	public int price; //가격
	public float time; //서비스 시간
	#endregion

	public float Time
	{
		get { return time; }
	}

	public int Price
	{
		get { return price; }
	}
}
