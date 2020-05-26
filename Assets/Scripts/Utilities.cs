using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
	private static Camera mainCamera = null;
	public static Camera MainCamera
	{
		get
		{
			if(mainCamera == null)
			{
				mainCamera = Camera.main;
			}
			return mainCamera;
		}
	}

	public static Vector2 GetMouseWorldPosition()
	{
		Vector3 pos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		return pos;
	}
}
