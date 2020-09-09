using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject prefabBlock;


    void CreateWall(Vector2 position, int wallHeight)
    {
        for (int y = 1; y < wallHeight; y++)
        {
            GameObject newWall = Instantiate(prefabBlock, new Vector3(position.x, y, position.y), Quaternion.identity);
            newWall.transform.parent = this.gameObject.transform;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        // create room
        int roomWidth = Random.Range(15, 30);
        int roomLenght = Random.Range(15, 30);

        // determine how many paths point away from the room

        int pathWidth = Random.Range(3, 5);

        int pathLength = Random.Range(5, 15);

        Vector2 pathBottom = new Vector2(Random.Range(2, roomWidth - pathWidth), 0);
        Vector2 pathTop = new Vector2(Random.Range(2, roomWidth- pathWidth), roomLenght);
        Vector2 pathLeft = new Vector2(0, Random.Range(2, roomLenght-pathWidth));
        Vector2 pathRight = new Vector2(roomWidth, Random.Range(2, roomLenght- pathWidth));

        bool hasBotPath = true, hasTopPath = false, hasLeftPath = false, hasRightPath = false;
        while(hasBotPath == false && hasTopPath == false && hasLeftPath == false && hasRightPath == false)
        {
            hasBotPath = (Random.value > 0.5f);
            hasTopPath = (Random.value > 0.5f);
            hasLeftPath = (Random.value > 0.5f);
            hasRightPath = (Random.value > 0.5f);
        }

        Debug.Log(hasBotPath + " " + hasTopPath + " " + hasLeftPath + " " + hasRightPath);

        for (int z = 0; z < roomLenght+1; z++)
        {
            for(int x = 0; x < roomWidth+1; x++)
            {
                // floor
                GameObject newTile = Instantiate(prefabBlock, new Vector3(x, 0, z), Quaternion.identity);
                newTile.transform.parent = this.gameObject.transform;

                // wall
                if(x == 0 || z == 0 || x == roomWidth || z == roomLenght)
                {
                    if (hasBotPath == true)
                    {
                        if (x == pathBottom.x && z == pathBottom.y)
                        {
                            CreateWall(new Vector2(x, z), 10);

                            

                            for(int Pz = 0; Pz < pathLength; Pz--)
                            {
                                for(int Px = x; Px < pathWidth; Px++)
                                {
                                    GameObject newPath = Instantiate(prefabBlock, new Vector3(Px, 0, Pz), Quaternion.identity);
                                    Debug.Log("path lol");
                                    newPath.transform.parent = this.gameObject.transform;
                                }
                            }

                            Debug.Log("Bot Path");
                            hasBotPath = false;
                        }
                        else
                        {
                            CreateWall(new Vector2(x, z), Random.Range(2, 5));
                        }
                    }
                    if (hasTopPath == true)
                    {
                        if (x == pathTop.x && z == pathTop.y)
                        {
                            CreateWall(new Vector2(x, z), 10);
                            Debug.Log("Top Path");
                            hasTopPath = false;
                        }
                        else
                        {
                            CreateWall(new Vector2(x, z), Random.Range(2, 5));
                        }
                    }
                    if (hasLeftPath == true)
                    {
                        if (x == pathLeft.x && z == pathLeft.y)
                        {
                            CreateWall(new Vector2(x, z), 10);
                            Debug.Log("Left Path");
                            hasLeftPath = false;
                        }
                        else
                        {
                            CreateWall(new Vector2(x, z), Random.Range(2, 5));
                        }
                    }
                    if (hasRightPath == true)
                    {
                        if (x == pathRight.x && z == pathRight.y)
                        {
                            CreateWall(new Vector2(x, z), 10);
                            Debug.Log("Right Path");
                            hasRightPath = false;
                        }
                        else
                        {
                            CreateWall(new Vector2(x, z), Random.Range(2, 5));
                        }
                    }

                    if(hasRightPath == false && hasLeftPath == false && hasTopPath == false && hasBotPath == false)
                        CreateWall(new Vector2(x, z), Random.Range(2, 5));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
