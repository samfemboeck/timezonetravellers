using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed;
    public bool onedge=false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        Bounds spriteBounds = GetComponent<SpriteRenderer>().bounds;
        
        Vector2 newPos =(Vector2)transform.position + setmovement();
        Bounds newBounds = new Bounds(newPos, spriteBounds.size);
        Bounds currentBound= new Bounds(transform.position, spriteBounds.size);
        
        if (Map.Instance.Encompasses(newBounds))transform.Translate(setmovement());

        
    }

    Vector2 setmovement()
    {
        Vector2 playerpos = player.transform.position;
        Vector2 Dir = (playerpos - (Vector2)transform.position);
        Dir = -Dir.normalized * (speed + Random.Range(0.1f, speed)) * Time.deltaTime;
        return Dir;
    }

    
}
