using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Bounds spriteBounds = GetComponent<SpriteRenderer>().bounds;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        Vector3 newPos = transform.position + move;
        Bounds newBounds = new Bounds(newPos, spriteBounds.size);
        if (Map.Instance.Encompasses(newBounds))
            transform.Translate(move);
    }
}
