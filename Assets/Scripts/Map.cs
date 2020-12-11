using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    public Vector3 MinWorldPos;
    public Vector3 MaxWorldPos;
    PolygonCollider2D _collider;

    void Awake()
    {
        Instance = this;
        _collider = GetComponent<PolygonCollider2D>();
    }

    public bool Contains(Vector3 position) => _collider.OverlapPoint(position);

    public Vector3 GetRandomPosition() => new Vector3(Random.Range(MinWorldPos.x, MaxWorldPos.x), Random.Range(MinWorldPos.y, MaxWorldPos.y));
}
