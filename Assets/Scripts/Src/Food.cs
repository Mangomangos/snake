using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    public Vector2Int Position;

    private void Awake()
    {
        Vector3 currScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(currScale, .1f);

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color currColor = renderer.color;
        renderer.color = Color.white;
        renderer.material.DOColor(currColor, .5f);
    }
}
