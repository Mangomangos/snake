using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Food FoodPrefab;
    public Food food;
    public SnakeController SnakePrefab;
    public SnakeController Snake;
    [SerializeField]
    // 10, 10 for the grid size is a grid size that spans -10  to 10
    private Vector2Int _gridSize = new Vector2Int(10, 10);
    [SerializeField]
    private float _minMoveInterval = 0.2f;
    private float _lastExecuted;
    [SerializeField] 
    private float _moveIntervalTime;
    // Start is called before the first frame update
    void Start()
    {
        Snake = Instantiate(SnakePrefab);
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastExecuted > _moveIntervalTime)
        {
            MoveSnake();
            _lastExecuted = Time.time;
        }
        if (Snake.GetHeadPosition() == food.Position)
        {
            Destroy(food.gameObject);
            Snake.AddSnakeSegment();
            SpawnFood();
            _moveIntervalTime = Mathf.Clamp(_moveIntervalTime * 0.9f, _minMoveInterval, float.MaxValue);
        }
    }

    private void MoveSnake()
    {
        Snake.Move();
    }

    private List<Vector2Int> GetEmptyGridSpaces()
    {
        List<Vector2Int> emptyGridSpaces = new();
        HashSet<Vector2Int> snakePositions = Snake.GetAllSnakeSegmentPositions();
        for (int i = -_gridSize.x; i <= _gridSize.x; i++)
        {
            for (int j = -_gridSize.y ; j <= _gridSize.y; j++)
            {
                Vector2Int currentGridSpot = new Vector2Int(i, j);
                if (!snakePositions.Contains(currentGridSpot))
                {
                    emptyGridSpaces.Add(currentGridSpot);
                }
            }
        }
        return emptyGridSpaces;
    } 
    private void SpawnFood()
    {
        food = Instantiate(FoodPrefab);
        List<Vector2Int> spawnSpots = GetEmptyGridSpaces();
        Vector2Int spawnSpot = spawnSpots[Random.Range(0, spawnSpots.Count-1)];
        food.Position = spawnSpot;
        food.transform.position = new Vector3(spawnSpot.x, spawnSpot.y, 0);

    }
}
