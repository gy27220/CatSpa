using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left)
		{
			Debug.Log("Mouse Click Button : Left");
		}
		else if(eventData.button == PointerEventData.InputButton.Middle)
		{
			Debug.Log("Mouse Click Button : Middle");
		}
		else if(eventData.button == PointerEventData.InputButton.Right)
		{
			Debug.Log("Mouse Click Button : Right");
		}

		Debug.Log("Mouse Position :" + eventData.position);
		Debug.Log("Mouse Click Count :" + eventData.clickCount);
	}
}
