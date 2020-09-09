using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject prefabBlock;





    // Start is called before the first frame update
    void Start()
    {

        // world gen lul

        // create room

        int roomWidth = Random.Range(15, 30);
        int roomLenght = Random.Range(15, 30);

        for(int z = 0; z < roomLenght+1; z++)
        {
            for(int x = 0; x < roomWidth+1; x++)
            {

                // floor
                GameObject newTile = Instantiate(prefabBlock, new Vector3(x, 0, z), Quaternion.identity);
                newTile.transform.parent = this.gameObject.transform;

                // wall
                if(x == 0 || z == 0 || x == roomWidth || z == roomLenght)
                {
                    int wallHeight = Random.Range(2, 4);
                    for(int y = 1; y < wallHeight; y++)
                    {
                        GameObject newWall = Instantiate(prefabBlock, new Vector3(x, y, z), Quaternion.identity);
                        newWall.transform.parent = this.gameObject.transform;
                    }
                }


            }
        }









    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
