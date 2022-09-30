using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
	private static SkillManager instance;

	public GameObject[] skill;

	int randomNum;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public static SkillManager Instance
	{
		get
		{
			if (instance == null)
				return null;

			return instance;
		}
	}


	public GameObject Skill_Random_Instantiate()
	{
		randomNum = Random.Range(0, skill.Length);
		return Instantiate(skill[randomNum]);
	}


	public GameObject Skill_Select(Vector2 pos)
	{
		GameObject obj = Skill_Random_Instantiate();

		obj.transform.position = new Vector2(pos.x, pos.y);
		obj.SetActive(true);
		return obj;
	}
}
