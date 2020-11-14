using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    public Vector3 MinWorldPos;
    public Vector3 MaxWorldPos;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        MinWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z));
        MaxWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, -Camera.main.transform.position.z));
    }

    public bool Encompasses(Bounds bounds) => Contains(bounds.min) && Contains(bounds.max);

    public bool Contains(Vector3 position) => position.x >= MinWorldPos.x && position.x <= MaxWorldPos.x && position.y >= MinWorldPos.y && position.y <= MaxWorldPos.y;

    public Vector3 GetRandomPosition() => new Vector3(Random.Range(MinWorldPos.x, MaxWorldPos.x), Random.Range(MinWorldPos.y, MaxWorldPos.y));

    // Update is called once per frame
    void Update()
    {
        
    }
}
