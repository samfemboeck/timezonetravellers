using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed;
    [SerializeField] float fleeingrange=3f;
    [Tooltip("The amount of time the wind acts on balloon")]
    [SerializeField] float timeofimpact;
    public bool onedge = false;
    Rigidbody2D rb;
    float timefornextwind = 5f;
    float nextwindoccurrencetime;
    int windcount=1;

    // Start is called before the first frame update
    void Start()
    {
        nextwindoccurrencetime = Time.time + timefornextwind;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        wind();
    }

    Vector2 setmovement()
    {
        Vector2 playerpos = player.transform.position;
        Vector2 Dir = (playerpos - (Vector2)transform.position);
        Dir = -Dir.normalized * (speed + Random.Range(0.1f, speed)) * Time.deltaTime;
        return Dir;
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
        FindObjectOfType<ScoreKeeper>().addscore();
        Destroy(gameObject);
    }

    void wind()
    {
        int a = Random.Range(0, 100);
        if (nextwindoccurrencetime > Time.time&& a<25)
        {
            nextwindoccurrencetime = Time.time + timefornextwind;
            if (windcount == 1)
            {
                rb.AddForce(Vector2.up, ForceMode2D.Impulse);
            }
            else if (windcount == 2)
            {
                rb.AddForce(Vector2.right, ForceMode2D.Impulse);
            }
            else if (windcount == 3)
            {
                rb.AddForce(Vector2.left, ForceMode2D.Impulse);  
            }
            else if (windcount == 4)
            {
                rb.AddForce(Vector2.down, ForceMode2D.Impulse);
            }
            if (windcount < 4)windcount++;
            else windcount = 0;
            Invoke("setspeedaszero",timeofimpact);
            
        }
    }

    void setspeedaszero()
    {
        rb.velocity = Vector2.zero;
    }
}
