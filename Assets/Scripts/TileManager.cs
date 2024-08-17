using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles;
    public float zSpawn;
    public float tileLength = 0.1f;
    public int tilesCount;
    public int tilesTotalCount;
    public Transform playerTransform;

    void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < tilesTotalCount; i++)
        {
            SpawnTile(i);
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

    }

    public void SpawnTile(int tileIndex)
    {
        GameObject tile = Instantiate(
            tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        tile.SetActive(true);
        activeTiles.Add(tile);
        zSpawn += tileLength;
    }
}
