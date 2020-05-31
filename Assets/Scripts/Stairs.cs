using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StairsSave
{
	public string name;
	public int x, y, z;
	public float xScale;
}

public class Stairs : Block
{
	private void Awake()
	{
		transform.localScale = new Vector3(Mathf.Sign(Player.Instance.transform.position.x - transform.position.x), 1, 1);
	}
	
	public StairsSave Save(int x, int y, int z)
	{
		return new StairsSave() { name = BlockName, xScale = transform.localScale.x, x = x, y = y, z = z};
	}
	
	public void Load(StairsSave data)
	{
		transform.localScale = new Vector3(data.xScale, 1, 1);
	}
}
