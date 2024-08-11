using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGenerator : MonoBehaviour
{
    public static MazeGenerator instance;
    public Material[] materials;
    public GameObject[] walls;
    public GameObject floor, cyling;
    [SerializeField]
    private MazeCell _mazeCellPrefab;

    public GameObject[] zombieGenerators;

    public int _mazeWidth;

    public int _mazeDepth;

    public static int lvl = 0;

    private MazeCell[,] _mazeGrid;

    public GameObject chestPrefab;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(lvl == 8)
        {
            SceneManager.LoadScene(2);
        }
        else if(lvl >= 5)
        {
            zombieGenerators[0].SetActive(true);
            zombieGenerators[1].SetActive(true);
            Debug.Log("10x10");
            _mazeWidth = 10;
            _mazeDepth = 10;
        }
        else if(lvl >= 3)
        {
            zombieGenerators[0].SetActive(true);
            Debug.Log("10x5");
            _mazeWidth = 10;
            _mazeDepth = 5;
        }
        else if(lvl == 2)
        {
            zombieGenerators[0].SetActive(true);
            Debug.Log("5x10");
            _mazeWidth = 5;
            _mazeDepth = 10;
        }
        else
        {
            Debug.Log("5x5");
            _mazeWidth = 5;
            _mazeDepth = 5;
        }
    }
    void Start()
    {
        lvl = lvl + 1;
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int z = 0; z < _mazeDepth; z++)
            {
                _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);

    }

    void Update()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        
        if(lvl == 7)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[7];
            }
            floor.GetComponent<MeshRenderer>().material = materials[6];
            cyling.GetComponent<MeshRenderer>().material = materials[6];
        }
        else if(lvl == 6)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[5];
            }
            floor.GetComponent<MeshRenderer>().material = materials[6];
            cyling.GetComponent<MeshRenderer>().material = materials[4];
        }
        else if(lvl == 5)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[5];
            }
            floor.GetComponent<MeshRenderer>().material = materials[4];
            cyling.GetComponent<MeshRenderer>().material = materials[4];
        }
        else if(lvl == 4)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[3];
            }
            floor.GetComponent<MeshRenderer>().material = materials[4];
            cyling.GetComponent<MeshRenderer>().material = materials[2];
        }
        else if(lvl == 3)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[3];
            }
            floor.GetComponent<MeshRenderer>().material = materials[2];
            cyling.GetComponent<MeshRenderer>().material = materials[2];
        }
        else if(lvl == 2)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[1];
            }
            floor.GetComponent<MeshRenderer>().material = materials[2];
            cyling.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = materials[5];
            }
            floor.GetComponent<MeshRenderer>().material = materials[4];
            cyling.GetComponent<MeshRenderer>().material = materials[4];
        }
        
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);


    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, z];
            
            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, z - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

}
