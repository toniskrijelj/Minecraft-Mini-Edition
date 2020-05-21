using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid
{
	public static BlockGrid Instance { get; private set; }

    //public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private Block[,] gridArray;

    public BlockGrid(int width, int height, float cellSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new Block[width, height];

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

    public void SetBlock(int x, int y, Block block) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
			if(block == null)
			{
				if (gridArray[x, y] != null)
				{
					UnityEngine.Object.Destroy(gridArray[x, y].GameObject);
				}
			}
            gridArray[x, y] = block;
            //OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }
    }

    /*public void TriggerGridObjectChanged(int x, int y) {
        OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }*/

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

    public Block GetBlock(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return GetBlock(x, y);
    }

}
