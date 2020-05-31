using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum Layer
{
	Background,
	Ground,
}

[System.Serializable]
public class BlockSaveData
{
	public string blockName;
	public int x, y, z;

	public BlockSaveData(string name, int x, int y, int z)
	{
		blockName = name;
		this.x = x;
		this.y = y;
		this.z = z;
	}
}

public class BlockGridSaveData
{
	public BlockSaveData[] blocks;
	public ChestData[] chests;
	public FurnaceSaveData[] furnaces;
	public DoorSave[] doors;
	public StairsSave[] stairs;

	public void Setup()
	{
		blocks = blocksList.ToArray();
		chests = chestsList.ToArray();
		furnaces = furnacesList.ToArray();
		doors = doorsList.ToArray();
		stairs = stairsList.ToArray();
	}

	private List<BlockSaveData> blocksList = new List<BlockSaveData>();
	private List<ChestData> chestsList = new List<ChestData>();
	private List<FurnaceSaveData> furnacesList = new List<FurnaceSaveData>();
	private List<DoorSave> doorsList = new List<DoorSave>();
	private List<StairsSave> stairsList= new List<StairsSave>();

	public void Add(Block block, int x, int y, int z)
	{
		if(block is Furnace)
		{
			furnacesList.Add(((Furnace)block).Save(x,y,z));
		}
		else if(block is Chest)
		{
			chestsList.Add(((Chest)block).Save(x,y,z));
		}
		else if (block is Door)
		{
			doorsList.Add(((Door)block).Save(x,y,z));
		}
		else if (block is Stairs)
		{
			stairsList.Add(((Stairs)block).Save(x,y,z));
		}
		else
		{
			blocksList.Add(new BlockSaveData(block.BlockName, x, y, z));
		}
	}
}

public class BlockGrid : MonoBehaviour
{
	public static BlockGrid Instance { get; private set; }

    private const int width = 127;
	private const int height = 127;
	private const float cellSize = 1;
	private static readonly Vector3 originPosition = new Vector3(-63, -63);
	public Block[,,] gridArray;

	private void Awake()
	{
		Instance = this;
		DeathScreen.OnQuit += Save;
		gridArray = new Block[width, height, 2];
	}

	private void Start()
	{
		if (!Load())
		{
			for (int i = 0; i < 127; i++)
			{
				BlockType.GrassBlock.Place(GetWorldPosition(i, 63), Layer.Ground);
				for (int j = 62; j >= 53; j--)
				{
					BlockType.Dirt.Place(GetWorldPosition(i, j), Layer.Ground);
				}
				for (int j = 52; j >= 0; j--)
				{
					BlockType.Stone.Place(GetWorldPosition(i, j), Layer.Background);
				}
				for (int j = 52; j >= 45; j--)
				{
					BlockType.Stone.Place(GetWorldPosition(i, j), Layer.Ground);
				}
				BlockType.CoalOre.Place(GetWorldPosition(i, 44), Layer.Ground);
				for (int j = 43; j >= 35; j--)
				{
					BlockType.Stone.Place(GetWorldPosition(i, j), Layer.Ground);
				}
				BlockType.IronOre.Place(GetWorldPosition(i, 34), Layer.Ground);
				for (int j = 33; j >= 26; j--)
				{
					BlockType.Stone.Place(GetWorldPosition(i, j), Layer.Ground);
				}
				BlockType.GoldOre.Place(GetWorldPosition(i, 25), Layer.Ground);
				for (int j = 24; j >= 15; j--)
				{
					BlockType.Stone.Place(GetWorldPosition(i, j), Layer.Ground);
				}
				BlockType.DiamondOre.Place(GetWorldPosition(i, 14), Layer.Ground);
				for (int j = 13; j >= 0; j--)
				{
					BlockType.Stone.Place(GetWorldPosition(i, j), Layer.Ground);
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					BlockType.OakLog.Place(GetWorldPosition(10 + j * 30, i + 64), Layer.Background);
					BlockType.SpruceLog.Place(GetWorldPosition(20 + j * 30, i + 64), Layer.Background);
					BlockType.BirchLog.Place(GetWorldPosition(30 + j * 30, i + 64), Layer.Background);
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					BlockType.OakLeaves.Place(GetWorldPosition(10 + i * 30 - 2 + j, 3 + 64), Layer.Ground);
					BlockType.SpruceLeaves.Place(GetWorldPosition(20 + i * 30 - 2 + j, 3 + 64), Layer.Ground);
					BlockType.OakLeaves.Place(GetWorldPosition(30 + i * 30 - 2 + j, 3 + 64), Layer.Ground);

					BlockType.OakLeaves.Place(GetWorldPosition(10 + i * 30 - 2 + j, 4 + 64), Layer.Ground);
					BlockType.SpruceLeaves.Place(GetWorldPosition(20 + i * 30 - 2 + j, 4 + 64), Layer.Ground);
					BlockType.OakLeaves.Place(GetWorldPosition(30 + i * 30 - 2 + j, 4 + 64), Layer.Ground);
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					BlockType.OakLeaves.Place(GetWorldPosition(10 + i * 30 - 1 + j, 5 + 64), Layer.Ground);
					BlockType.SpruceLeaves.Place(GetWorldPosition(20 + i * 30 - 1 + j, 5 + 64), Layer.Ground);
					BlockType.OakLeaves.Place(GetWorldPosition(30 + i * 30 - 1 + j, 5 + 64), Layer.Ground);
				}
			}
		}
	}

	private bool Load()
	{
		if (File.Exists(Application.dataPath + "/blocks.txt"))
		{
			BlockGridSaveData data = JsonUtility.FromJson<BlockGridSaveData>(File.ReadAllText(Application.dataPath + "/blocks.txt"));
			for (int i = 0; i < data.blocks.Length; i++)
			{
				BlockType.GetBlockType(data.blocks[i].blockName).Place(GetWorldPosition(data.blocks[i].x, data.blocks[i].y), (Layer)data.blocks[i].z);
			}
			for(int i = 0; i < data.chests.Length; i ++)
			{
				Chest chest = (Chest)BlockType.Chest.Place(GetWorldPosition(data.chests[i].x, data.chests[i].y), (Layer)data.chests[i].z);
				chest.Load(data.chests[i]);
			}
			for(int i = 0; i < data.furnaces.Length; i++)
			{
				Furnace furnace = (Furnace)BlockType.Furnace.Place(GetWorldPosition(data.furnaces[i].x, data.furnaces[i].y), (Layer)data.furnaces[i].z);
				furnace.Load(data.furnaces[i]);
			}
			for (int i = 0; i < data.stairs.Length; i++)
			{
				Stairs stairs = (Stairs)BlockType.GetBlockType(data.stairs[i].name).Place(GetWorldPosition(data.stairs[i].x, data.stairs[i].y), (Layer)data.stairs[i].z);
				stairs.Load(data.stairs[i]);
			}
			for (int i = 0; i < data.doors.Length; i++)
			{
				Door door = (Door)BlockType.Door.Place(GetWorldPosition(data.doors[i].x, data.doors[i].y), (Layer)data.doors[i].z);
				door.Load(data.doors[i]);
			}
			return true;
		}
		return false;
	}

	private void Save()
	{
		BlockGridSaveData save = new BlockGridSaveData();
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				for(int k = 0; k < 2; k++)
				{
					if(gridArray[i, j, k] != null)
					{
						save.Add(gridArray[i, j, k], i, j, k);
					}
				}
			}
		}
		save.Setup();
		File.WriteAllText(Application.dataPath + "/blocks.txt", JsonUtility.ToJson(save));
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
