using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
	public static Camera MainCamera { get; private set; }

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		MainCamera = Camera.main;
	}

	public static Vector2 GetMouseWorldPosition()
	{
		Vector3 pos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		return pos;
	}
}
