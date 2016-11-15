using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour
{
    public GameObject Wall;
    public int xSize = 5;
    public int ySize = 5;
    public float wallLength = 1f;
    private Vector3 initalPos;
    private GameObject wallHolder;

    void Start()
    {
        CreateWalls();
    }

    void CreateWalls()
    {
        wallHolder = new GameObject();
        wallHolder.name = "Maze";

        initalPos = new Vector3((-xSize / 2) + wallLength / 2, 0, (-ySize / 2) + wallLength / 2);
        Vector3 myPos = initalPos;
        GameObject tempWall;

        //for x axis
        for(int i = 0; i < ySize; i++)
        {
            for (int j = 0; j <= xSize; j++)
            {
                myPos = new Vector3(initalPos.x + (j * wallLength) - wallLength / 2, 0, initalPos.z + (i * wallLength) - wallLength/2);
                tempWall = Instantiate(Wall,myPos,Quaternion.identity) as GameObject;
                tempWall.transform.parent = wallHolder.transform;
            }
        }

        //for y axis
        for (int i = 0; i <= ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                myPos = new Vector3(initalPos.x + (j * wallLength), 0, initalPos.z + (i * wallLength) - wallLength);
                tempWall = Instantiate(Wall, myPos, Quaternion.Euler(0,90,0)) as GameObject;
                tempWall.transform.parent = wallHolder.transform;
            }
        }
    }

    void Update()
    {

    }
}
