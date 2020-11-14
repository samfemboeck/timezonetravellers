using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed;
    [SerializeField] float fleeingrange;
    
    public bool onedge = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        Bounds spriteBounds = GetComponent<SpriteRenderer>().bounds;
        if (isplayerinrange())
        {
            speed = 0.2f;
            Vector2 newPos = (Vector2)transform.position + setmovement();
            Bounds newBounds = new Bounds(newPos, spriteBounds.size);
            if (Map.Instance.Encompasses(newBounds)) transform.Translate(setmovement());
        }
        if (onedge)
        {
            speed = 5f;
            Vector2 newPos = (Vector2)transform.position + randommovement();
            Bounds newBounds = new Bounds(newPos, spriteBounds.size);
            if (Map.Instance.Encompasses(newBounds))
            {
                transform.Translate(randommovement());
            
            }
        }

    }

    Vector2 setmovement()
    {
        Vector2 playerpos = player.transform.position;
        Vector2 Dir = (playerpos - (Vector2)transform.position);
        Dir = -Dir.normalized * (speed + Random.Range(0.1f, speed)) * Time.deltaTime;
        return Dir;
    }


     Vector2 randommovement()
     {
         Vector2 movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
         movement = movement.normalized * Time.deltaTime*speed;
         return movement;
     }

    bool isplayerinrange() => Vector2.Distance(transform.position, player.transform.position) < fleeingrange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Stone>())
        {
            Destroy(collision.gameObject);
            GetComponent<Animator>().SetTrigger("pop");
        }
    }
    public void pop()
    {
        Destroy(gameObject);
    }

    

    void shake()
    {

    }
}
