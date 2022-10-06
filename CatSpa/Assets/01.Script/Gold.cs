using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
	public int gold;

	Drag objectClick;
	float speed;
	float alphaSpeed;
	float destroyTime;
	Color alpha;


	private void Start()
	{
		gold = 0;
		alpha = this.GetComponent<SpriteRenderer>().color;

		objectClick = GetComponent<Drag>();
		speed = 2f;
		alphaSpeed = 1f;
		destroyTime = 1f;
	}


	private void Update()
	{
		if (objectClick.MoneyClick)
		{
			transform.Translate(new Vector2(0, speed * Time.deltaTime));
			alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
			GetComponent<SpriteRenderer>().color = alpha;
			Invoke("DestroyObect", destroyTime);

			objectClick.MoneyClick = false;
		}
	}

	void DestroyObect()
	{
		GoldText.instance.setMoney(gold);
		Destroy(gameObject);
	}
}
