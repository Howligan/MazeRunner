using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour
{
    [System.Serializable]
    public class Cell
    {
        public bool visited;
        public GameObject North;
        public GameObject East;
        public GameObject West;
        public GameObject South;
    }

    public GameObject Wall;
    public int xSize = 5;
    public int ySize = 5;
    public float wallLength = 1f;
    private Vector3 initalPos;
    private GameObject wallHolder;
    private Cell[] cells;


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
        CreateCells();
    }

    void CreateCells()
    {
        GameObject[] allWalls;
        int children = wallHolder.transform.childCount;
        allWalls = new GameObject[children];
        cells = new Cell[xSize * ySize];
        int eastWestProcess = 0;
        int childProcess = 0;
        int termCount = 0;


        // Get all the children
        for (int i = 0; i < children; i++)
        {
            allWalls[i] = wallHolder.transform.GetChild(i).gameObject;
        }
        // Assigns walls to the cells
        for (int cellprocess = 0; cellprocess < cells.Length; cellprocess++)
        {
            cells[cellprocess] = new Cell ();
            cells[cellprocess].East = allWalls[eastWestProcess];
            cells[cellprocess].South = allWalls[childProcess + (xSize+1) * ySize];
            if (termCount == xSize)
            {
                eastWestProcess += 2;
                termCount = 0;
            }
            else
                eastWestProcess++;

            termCount++;
            childProcess++;
            cells[cellprocess].West = allWalls[eastWestProcess];
            cells[cellprocess].North = allWalls[(childProcess + (xSize + 1) * ySize) + xSize-1];
        }
    }

    void Update()
    {

    }
}
