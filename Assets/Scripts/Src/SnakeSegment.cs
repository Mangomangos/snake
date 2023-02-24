using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeSegment : MonoBehaviour
{
    public Vector2Int CurrentPosition;
    public Vector2Int LastPosition;
    
    public Gradient ColorGradient;
    private Tween currentTween;

    public void SetVisuals(float percent)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = ColorGradient.Evaluate(percent);
    }

    public void MoveTo(Vector2Int position)
    {
        LastPosition = CurrentPosition;
        CurrentPosition = position;
        transform.position = new Vector3(CurrentPosition.x, CurrentPosition.y, 0);
    }

}
