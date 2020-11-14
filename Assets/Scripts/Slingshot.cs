using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject StonePrefab;
    Vector3 _initialMousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _initialMousePos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            if (_initialMousePos != Input.mousePosition)
            {
                GameObject stone = Instantiate(StonePrefab, transform.position, Quaternion.identity);
                stone.GetComponent<Stone>().Direction = (_initialMousePos - Input.mousePosition).normalized;
            }
        }
    }
}
