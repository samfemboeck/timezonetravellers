using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float MarginAntigravity;
    public float RandomFactor;
    public float Margin;
    public float MaxSpeed;
    public float WindWeight;
    public float PlayerAntiGravityWeight;
    public float Fleeingrange;

    Transform _playerTransform;
    Rigidbody2D _rb;
    Vector3 _playerAntiGravity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        _playerAntiGravity = Vector3.zero;
        if (IsPlayerInRange())
            _playerAntiGravity = (transform.position - _playerTransform.position).normalized;
    }

    private void FixedUpdate()
    {
        // Margin Antigravity
        if (transform.position.x < Map.Instance.MinWorldPos.x + Margin)
        {
            _rb.AddForce(Vector3.right * MarginAntigravity);
        }
        if (transform.position.x > Map.Instance.MaxWorldPos.x - Margin)
        {
            _rb.AddForce(Vector3.left * MarginAntigravity);
        }
        if (transform.position.y < Map.Instance.MinWorldPos.y + Margin)
        {
            _rb.AddForce(Vector3.up * MarginAntigravity);
        }
        if (transform.position.y > Map.Instance.MaxWorldPos.y - Margin)
        {
            _rb.AddForce(Vector3.down * MarginAntigravity);
        }

        // Wind
        _rb.AddForce(Wind.Instance.Direction * WindWeight);

        // Player Antigravity
        _playerAntiGravity = Vector3.zero;
        if (IsPlayerInRange())
            _playerAntiGravity = (transform.position - _playerTransform.position).normalized;
        _rb.AddForce(_playerAntiGravity * PlayerAntiGravityWeight);

        if (_rb.velocity.magnitude > MaxSpeed)
            _rb.velocity = _rb.velocity.normalized * MaxSpeed;
    }

    bool IsPlayerInRange() => Vector2.Distance(transform.position, _playerTransform.position) < Fleeingrange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            Destroy(collision.gameObject);
            GetComponent<Animator>().SetTrigger("pop");
        }

        if (collision.gameObject.CompareTag("Baloon"))
        {
            _rb.AddForce(collision.gameObject.GetComponent<Rigidbody2D>().velocity * 10);
        }
    }

    public void Pop()
    {
        Destroy(gameObject);
    }
}
