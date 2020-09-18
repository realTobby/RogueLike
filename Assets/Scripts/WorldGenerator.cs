using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PathDirection
{
    Top,
    Bot,
    Left,
    Right
}

public class WorldGenerator : MonoBehaviour
{
    public GameObject prefabBlock;

    public List<Vector2> wallPositions = new List<Vector2>();

    void CreateWall(Vector2 position, int wallHeight)
    {
        if (!wallPositions.Exists(x => x == position))
        {
            for (int y = 1; y < wallHeight; y++)
            {
                GameObject newWall = Instantiate(prefabBlock, new Vector3(position.x, y, position.y), Quaternion.identity);
                newWall.transform.parent = this.gameObject.transform;
            }
            wallPositions.Add(position);
        }
    }

    void CreateWall(Vector2 position,int offsetY, int wallHeight)
    { 
        if(!wallPositions.Exists(x=>x == position))
        {
            for (int y = offsetY; y < wallHeight; y++)
            {
                GameObject newWall = Instantiate(prefabBlock, new Vector3(position.x, y, position.y), Quaternion.identity);
                newWall.transform.parent = this.gameObject.transform;
            }
            wallPositions.Add(position);
        }
    }

    void CreatePath(Vector2 position, PathDirection direction, int floorLength, int floorWidth)
    {
        switch(direction)
        {
            case PathDirection.Bot:
                //Debug.Log("=== create bot path ===");
                for (int floorZ = (int)position.y; floorZ > (int)position.y - floorLength + 1; floorZ--)
                {
                    for (int floorX = (int)position.x; floorX < (int)position.x + floorWidth + 1; floorX++)
                    {
                        if(floorX == position.x || floorX == position.x + floorWidth)
                        {
                            CreateWall(new Vector2(floorX, floorZ), 5);
                        }
                        else
                        {
                            GameObject newTile = Instantiate(prefabBlock, new Vector3(floorX, 0, floorZ), Quaternion.identity);
                        }
                        wallPositions.Add(new Vector2(floorX, floorZ));
                    }
                }
                break;
            case PathDirection.Top:
                //Debug.Log("=== create top path ===");
                for (int floorZ = (int)position.y; floorZ < (int)position.y + floorLength +1 ; floorZ++)
                {

                    for (int floorX = (int)position.x; floorX < (int)position.x + floorWidth + 1; floorX++)
                    {
                        if (floorX == position.x || floorX == position.x + floorWidth)
                        {
                            CreateWall(new Vector2(floorX, floorZ), 5);
                        }
                        else
                        {
                            GameObject newTile = Instantiate(prefabBlock, new Vector3(floorX, 0, floorZ), Quaternion.identity);
                        }
                        wallPositions.Add(new Vector2(floorX, floorZ));
                    }
                }
                break;
            case PathDirection.Left:
                //Debug.Log("=== create left path ===");
                for(int floorZ = (int)position.y; floorZ > (int)position.y - floorWidth-1; floorZ--)
                {
                    for(int floorX = (int)position.x; floorX > (int)position.x - floorLength + 1; floorX--)
                    {
                        if (floorZ == position.y || floorZ == position.y - floorWidth)
                        {
                            CreateWall(new Vector2(floorX, floorZ), 5);
                        }
                        else
                        {
                            GameObject newTile = Instantiate(prefabBlock, new Vector3(floorX, 0, floorZ), Quaternion.identity);
                        }
                        wallPositions.Add(new Vector2(floorX, floorZ));
                    }
                }
                break;
            case PathDirection.Right:
                //Debug.Log("=== create right path ===");
                for(int floorZ = (int)position.y; floorZ > (int)position.y - floorWidth-1; floorZ--)
                {
                    for(int floorX = (int)position.x; floorX < (int)position.x + floorLength + 1; floorX++)
                    {
                        if (floorZ == position.y || floorZ == position.y - floorWidth)
                        {
                            CreateWall(new Vector2(floorX, floorZ), 5);
                        }
                        else
                        {
                            GameObject newTile = Instantiate(prefabBlock, new Vector3(floorX, 0, floorZ), Quaternion.identity);
                        }
                        wallPositions.Add(new Vector2(floorX, floorZ));
                    }
                }
                break;
        }
        //Debug.Log("path at " + position);
    }

    void CreateRoom(int startX, int startZ, int roomWidth, int roomLength)
    {
        for (int roomZIndex = startX; roomZIndex < startX + roomLength + 1; roomZIndex++)
        {
            for (int roomXIndex = startZ; roomXIndex < startZ + roomWidth + 1; roomXIndex++)
            {
                // wall
                if (roomXIndex == startX || roomZIndex == startZ || roomXIndex == startX + roomWidth || roomZIndex == startZ + roomLength)
                {
                    CreateWall(new Vector2(roomXIndex, roomZIndex), 5);
                }
                else
                {
                    // floor
                    GameObject newTile = Instantiate(prefabBlock, new Vector3(roomXIndex, 0, roomZIndex), Quaternion.identity);
                    newTile.transform.parent = this.gameObject.transform;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        

        // create room
        int roomWidth = Random.Range(15, 30);
        int roomLenght = Random.Range(15, 30);

        // determine how many paths point away from the room

        int pathWidth = Random.Range(5, 8);
        int pathLength = Random.Range(8, 15);

        Vector2 pathBottom = new Vector2(Random.Range(2, roomWidth - pathWidth), 0);
        Vector2 pathTop = new Vector2(Random.Range(2, roomWidth- pathWidth), roomLenght);
        Vector2 pathLeft = new Vector2(0, Random.Range(2, roomLenght-pathWidth));
        Vector2 pathRight = new Vector2(roomWidth, Random.Range(2, roomLenght- pathWidth));

        CreatePath(pathBottom, PathDirection.Bot, pathLength, pathWidth);
        CreatePath(pathTop, PathDirection.Top, pathLength, pathWidth);
        CreatePath(pathLeft, PathDirection.Left, pathLength, pathWidth);
        CreatePath(pathRight, PathDirection.Right, pathLength, pathWidth);

        int startX = 0;
        int startZ = 0;

        CreateRoom(startX, startZ, roomWidth, roomLenght);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
