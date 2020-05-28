using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Layer
{
	Background,
	Ground,
}

public class BlockGrid : MonoBehaviour
{
	public static BlockGrid Instance { get; private set; }

    private const int width = 64;
	private const int height = 64;
	private const float cellSize = 1;
	private static readonly Vector3 originPosition = new Vector3(-32, -32);
	public Block[,,] gridArray;

	private void Awake()
	{
		gridArray = new Block[width, height, 2];
		for (int i = 0; i < 16; i++)
		{
			Block block = Block.Place(Block.Prefab, GetWorldPosition(i+32, 32), 1, ToolType.Axe, ToolMaterial.All, BlockData.blockData.oakPlanksTexture, Item.OakPlanks);
			SetBlock(i+32, 32, Layer.Ground, block);
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

	public void SetBlock(int x, int y, Layer layer, Block block)
	{
		if (x >= 0 && y >= 0 && x < width && y < height)
		{
			gridArray[x, y, layer.ToInt()] = block;
		}
	}

	public void SetBlock(Vector2Int gridPosition, Layer layer, Block block)
	{
		SetBlock(gridPosition.x, gridPosition.y, layer, block);
	}

	public void SetBlock(Vector3 worldPosition, Layer layer, Block block) {
		GetXY(worldPosition, out int x, out int y);
		SetBlock(x, y, layer, block);
    }

    public Block GetBlock(int x, int y, Layer layer) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y, layer.ToInt()];
        } else {
            return default;
        }
    }

	public Block GetBlock(Vector2Int gridPosition, Layer layer)
	{
		return GetBlock(gridPosition.x, gridPosition.y, layer);
	}

    public Block GetBlock(Vector3 worldPosition, Layer layer) {
		GetXY(worldPosition, out int x, out int y);
		return GetBlock(x, y, layer);
    }

	public bool CanPlace(int x, int y, Layer layer, bool checkNearBlocks = true)
	{
		return CheckXY(x, y) &&
				GetBlock(x, y, layer) == null &&
				(!Physics2D.BoxCast(GetWorldPosition(x, y), new Vector2(.8f, .8f), 0, Vector2.zero, 0, 1 << 10) || Input.GetKey(KeyCode.LeftAlt)) &&
				(!checkNearBlocks || 
				GetBlock(x - 1, y, Layer.Background) != null ||
				GetBlock(x + 1, y, Layer.Background) != null ||
				GetBlock(x, y + 1, Layer.Background) != null ||
				GetBlock(x, y - 1, Layer.Background) != null ||
				GetBlock(x - 1, y, Layer.Ground) != null ||
				GetBlock(x + 1, y, Layer.Ground) != null ||
				GetBlock(x, y + 1, Layer.Ground) != null ||
				GetBlock(x, y - 1, Layer.Ground) != null);
	}

	public bool CanPlace(Vector2Int mouseGridPosition, Layer layer, bool checkNearBlocks = true)
	{
		return CanPlace(mouseGridPosition.x, mouseGridPosition.y, layer, checkNearBlocks);
	}
}
