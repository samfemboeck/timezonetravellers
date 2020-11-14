using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    Vector3 _minWorldPos;
    Vector3 _maxWorldPos;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _minWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z));
        _maxWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, -Camera.main.transform.position.z));

    }

    public bool Encompasses(Bounds bounds) => Contains(bounds.min) && Contains(bounds.max);

    public bool Contains(Vector3 position) => position.x >= _minWorldPos.x && position.x <= _maxWorldPos.x && position.y >= _minWorldPos.y && position.y <= _maxWorldPos.y;

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
