using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSwpawn : MonoBehaviour
{
    public GameObject[] mobs;
    int randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int y;
    private void Start()
    {
        y = Mathf.RoundToInt(transform.position.y);
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            int tempY = y;
            randX = Random.Range(0, 10);
            nextSpawn = Time.time + spawnRate;
            while (true)
            {
                if(BlockGrid.Instance.GetBlock(randX, tempY, Layer.Ground) != null)
                {
                    tempY++;
                }
                else
                {
                    break;
                }
            }
            whereToSpawn = new Vector2(randX, tempY + 1);
            GameObject mob = mobs[Random.Range(0, mobs.Length)];
            Instantiate(mob, whereToSpawn, Quaternion.identity);
        }
    }
}
