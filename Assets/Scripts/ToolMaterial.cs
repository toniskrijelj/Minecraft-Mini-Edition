using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMaterial : Enumeration
{
	public static readonly ToolMaterial All = new ToolMaterial(0, 1);
	public static readonly ToolMaterial Wood = new ToolMaterial(1, 2);
	public static readonly ToolMaterial Gold = new ToolMaterial(2, 12);
	public static readonly ToolMaterial Stone = new ToolMaterial(3, 4);
	public static readonly ToolMaterial Iron = new ToolMaterial(4, 6);
	public static readonly ToolMaterial Diamond = new ToolMaterial(5, 8);

	public bool StrongEnough(ToolMaterial blockRequiredMaterial)
	{
		return Value >= blockRequiredMaterial.Value;
	}

	public float Multiplier { get; }

	protected ToolMaterial(int value, float multiplier) : base(value)
	{
		Multiplier = multiplier;
	}
}