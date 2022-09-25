using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
	#region public º¯¼ö
	public GameObject[] oil;
	public int oilMaxCount;
	#endregion


	public GameObject Random_Select_Oil()
	{
		int rand = Random.Range(0, 3);
		
		if(rand == 0)
			Debug.Log(oil[0].GetComponent<SkilInformation>().name);

		if (rand == 1)
			Debug.Log(oil[1].GetComponent<SkilInformation>().name);

		if (rand == 2)
			Debug.Log(oil[2].GetComponent<SkilInformation>().name);

		return Instantiate(oil[rand]);
	}
}
