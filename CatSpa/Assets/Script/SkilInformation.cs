using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilInformation : MonoBehaviour
{
	//SkillInformation
	//오브젝트가 갖는 기본적인 특징
	#region public 변수
	public Texture2D image;
	public Text name; //string타입으로 바꿀지 고민. 일단 ㄱ
	public string explanation; //각 스킬에 대한 설명
	public int price; //가격
	public float time; //서비스 시간
	#endregion
}
