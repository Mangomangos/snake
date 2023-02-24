using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public System.Action<Food> OnNom;
    public float Speed = 1;
    public SnakeSegment SnakeSegmentPrefab;
    public List<SnakeSegment> SnakeSegments;
    private Vector2Int _direction = Vector2Int.right;
    private Vector2Int _lastUsedDirection = Vector2Int.zero;
    // Start is called before the first frame update
    void Start()
    {
        SnakeSegment snakeHead = Instantiate(SnakeSegmentPrefab);
        SnakeSegments.Add(snakeHead);

    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        if (xAxis > 0 && _lastUsedDirection != Vector2Int.left)
        {
            _direction = Vector2Int.right;
        } else if (xAxis < 0 && _lastUsedDirection != Vector2Int.right)
        {
            _direction = Vector2Int.left;
        } else if (yAxis > 0 && _lastUsedDirection != Vector2Int.down)
        {
            _direction = Vector2Int.up;
        } else if (yAxis < 0 && _lastUsedDirection != Vector2Int.up)
        {
            _direction = Vector2Int.down;
        }

    }

    public void Move()
    {
        SnakeSegments[0].MoveTo(SnakeSegments[0].CurrentPosition + _direction);
        for (int i = 1; i < SnakeSegments.Count; i++)
        {
            SnakeSegments[i].MoveTo(SnakeSegments[i - 1].LastPosition);
        }
        _lastUsedDirection = _direction;

    }

    public void AddSnakeSegment()
    {
        SnakeSegments.Add(Instantiate(SnakeSegmentPrefab));
        SnakeSegments[SnakeSegments.Count - 1].MoveTo(SnakeSegments[SnakeSegments.Count - 2].LastPosition);

        for (int i = 0; i < SnakeSegments.Count; i++)
        {
            SnakeSegments[i].SetVisuals((float)i / (float)SnakeSegments.Count);
        }
    }

    public Vector2Int GetHeadPosition()
    {
        return SnakeSegments[0].CurrentPosition;
    }

    public HashSet<Vector2Int> GetAllSnakeSegmentPositions()
    {
        HashSet<Vector2Int> snakePositions = new();
        foreach (var segment in SnakeSegments)
        {
            snakePositions.Add(segment.CurrentPosition);
        }

        return snakePositions;
    }
}
