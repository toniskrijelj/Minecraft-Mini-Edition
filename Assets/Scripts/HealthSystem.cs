using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : ResourceSystem
{
	[SerializeField]Material material = null;

	SpriteRenderer sr;

	protected override void Awake()
	{
		base.Awake();
		if(material == null)
		{
			sr = GetComponent<SpriteRenderer>();
		}
	}

	public override void Decrease(int decreaseAmount)
	{
		base.Decrease(decreaseAmount);
		StartCoroutine(FlashRed());

	}

	IEnumerator FlashRed()
	{
		if (material == null)
		{
			sr.color = Color.red;
		}
		else
		{
			material.color = Color.red;
		}
		yield return new WaitForSeconds(0.2f);
		if (material == null)
		{
			sr.color = Color.white;
		}
		else
		{
			material.color = Color.white;
		}
	}


}
