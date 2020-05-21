using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Enumeration : IComparable
{
	protected Enumeration()
	{

	}

	protected Enumeration(string displayName)
	{
		DisplayName = displayName;
	}

	protected Enumeration(int value)
	{
		Value = value;
	}

	protected Enumeration(int value, string displayName)
	{
		Value = value;
		DisplayName = displayName;
	}

	public int Value { get; }

	public string DisplayName { get; }

	public int CompareTo(object obj)
	{
		return Value.CompareTo(((Enumeration)obj).Value);
	}

	public override string ToString()
	{
		return DisplayName;
	}
}
