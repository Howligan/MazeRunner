﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze mazeInstance;

    // Use this for initialization
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
    }

    void RestartGame()
    {
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
