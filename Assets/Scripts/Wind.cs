using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public static Wind Instance;
    public float ChangeDirectionInterval;
    public Vector3 Direction;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        InvokeRepeating("ChangeDirection", 0, ChangeDirectionInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeDirection() => Direction = Random.insideUnitCircle.normalized;
}
