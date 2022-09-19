using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCloseButton : MouseClick
{
	public GameObject obj;

	public void ButtonClick()
	{
		obj.SetActive(false);
	}
}
