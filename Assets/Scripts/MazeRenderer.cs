using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField] MazeGeneratorNew mazeGenerator;
    [SerializeField] GameObject mazeCellPrefab;

    public float cellSize = 1f;

    private void Start()
    {
        MazeCellNew[,] maze = mazeGenerator.GetMaze();

        for(int x = 0; x< maze.Length; x++)
        {
            for(int y = 0; y< mazeGenerator.mazeHeight; y++)
            {
                GameObject newCell = Instantiate( mazeCellPrefab, new Vector3( (float)x * cellSize, 0f, (float)y * cellSize ), Quaternion.identity,transform );
                MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();

                bool top = maze[x, y].topWall;
                bool left = maze[x, y].leftWall;

                bool right = false;
                bool bottom = false;
                if (x == mazeGenerator.mazeWidth - 1) right = true;
                if (y == 0) bottom = true;

                mazeCell.Init( top, bottom, right, left );
            }
        }
    }
}
