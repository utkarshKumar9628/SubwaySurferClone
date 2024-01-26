using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tile;
    public float zSpawn = 0f;
    public float tileLength = 34f;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    private  List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++) 
        {
            if (i == 0)
            {
                SpawnTile(0);

            }
            else
            {
                SpawnTile(Random.Range(0, tile.Length));

            }
            
        
        
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (numberOfTiles * tileLength))
        {

            SpawnTile(Random.Range(0, tile.Length));
            DeleteTile();

        }
    }

    public void SpawnTile(int tileIndex)
    {

        GameObject go =Instantiate(tile[tileIndex],transform.forward * zSpawn,transform.rotation);
        zSpawn = zSpawn + tileLength;
        activeTiles.Add(go);
    
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
