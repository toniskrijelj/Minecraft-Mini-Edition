using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
	public static bool RightTool(this ToolType tool, ToolType toolForBlock)
	{
		if (tool == toolForBlock) return true;
		return toolForBlock == ToolType.None;
	}	
}