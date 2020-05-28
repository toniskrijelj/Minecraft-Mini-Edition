using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
	public static bool CanHarvest(this ToolType tool, ToolType toolForBlock)
	{
		if (tool == toolForBlock) return true;
		return toolForBlock != ToolType.Pickaxe;
	}

	public static bool RightTool(this ToolType tool, ToolType toolForBlock)
	{
		return tool == toolForBlock;
	}

	public static int ToInt(this Layer layer)
	{
		return (int)layer;
	}
}