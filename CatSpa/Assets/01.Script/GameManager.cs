using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	List<int> randomNumList = new List<int>();

	private void Start()
	{
		CreateRandomNumber();
	}


	void CreateRandomNumber()
	{
		int currentNumber = Random.Range(0, 6);

		for (int i = 0; i < 6;)
		{
			if (randomNumList.Contains(currentNumber))
			{
				currentNumber = Random.Range(0, 6);
			}
			else
			{
				randomNumList.Add(currentNumber);
				i++;
			}
		}
	}
}
