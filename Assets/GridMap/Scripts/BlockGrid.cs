using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour
{
	public static BlockGrid Instance { get; private set; }

    private const int width = 16;
	private const int height = 16;
	private const float cellSize = 1;
	private static readonly Vector3 originPosition = new Vector3(-8, -8);
	public Block[,] gridArray;

	private void Awake()
	{
		gridArray = new Block[width, height];
		for (int i = 0; i < 16; i++)
		{
						//Block.Place(worldPosition, Hardness, ToolType, ToolMaterial, Texture(), Item, Input.GetKey(KeyCode.LeftAlt))
			Block block = Block.Place(GetWorldPosition(i, 8), 1, ToolType.Axe, ToolMaterial.All, BlockData.blockData.oakPlanksTexture, Item.OakPlanks);
			SetBlock(i, 8, block);
		}
		Instance = this;
	}

    public int GetWidth() {
        return width;
    }

    public int GetHeight() {
        return height;
    }

    public float GetBlockSize() {
        return cellSize;
    }

    public Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

	public Vector3 GetWorldPosition(Vector2Int gridPosition)
	{
		return GetWorldPosition(gridPosition.x, gridPosition.y);
	}

	public Vector2Int GetXY(Vector3 worldPosition)
	{
		GetXY(worldPosition, out int x, out int y);
		return new Vector2Int(x, y);
	}

	public bool CheckXY(int x, int y)
	{
		return x >= 0 && y >= 0 && x < width && y < height;
	}

	public bool CheckXY(Vector2Int gridPosition)
	{
		return CheckXY(gridPosition.x, gridPosition.y);
	}

	public void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.RoundToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.RoundToInt((worldPosition - originPosition).y / cellSize);
    }

	public void SetBlock(int x, int y, Block block)
	{
		if (x >= 0 && y >= 0 && x < width && y < height)
		{
			gridArray[x, y] = block;
		}
	}

	public void SetBlock(Vector2Int gridPosition, Block value)
	{
		SetBlock(gridPosition.x, gridPosition.y, value);
	}

	public void SetBlock(Vector3 worldPosition, Block value) {
		GetXY(worldPosition, out int x, out int y);
		SetBlock(x, y, value);
    }

    public Block GetBlock(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        } else {
            return default;
        }
    }

	public Block GetBlock(Vector2Int gridPosition)
	{
		return GetBlock(gridPosition.x, gridPosition.y);
	}

    public Block GetBlock(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return GetBlock(x, y);
    }

	public bool CanPlace(int x, int y)
	{
		return CheckXY(x, y) &&
				GetBlock(x, y) == null &&
				(!Physics2D.BoxCast(GetWorldPosition(x, y), new Vector2(.8f, .8f), 0, Vector2.zero, 0, 1 << 10) || Input.GetKey(KeyCode.LeftAlt)) &&
				(GetBlock(x - 1, y) != null ||
				GetBlock(x + 1, y) != null ||
				GetBlock(x, y + 1) != null ||
				GetBlock(x, y - 1) != null);
	}

	public bool CanPlace(Vector2Int mouseGridPosition)
	{
		return CanPlace(mouseGridPosition.x, mouseGridPosition.y);
	}
}
