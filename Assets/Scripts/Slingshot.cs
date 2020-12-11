using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject StonePrefab;
    public GameEvent OnSlingshot;
    public bool IsCollected = false;
    public float IndicatorLength;
    Vector3 _initialMousePos;
    Vector3 _dir;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    LineRenderer _lineRenderer;
    bool _isCharging = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        if (!IsCollected)
            return;

        if (Input.GetMouseButtonDown(0) && _spriteRenderer.bounds.Contains(GetMousePos()))
        {
            _initialMousePos = Input.mousePosition;
            _animator.SetTrigger("charge");
            _isCharging = true;
            _lineRenderer.enabled = true;
        }

        if (_isCharging && Input.GetMouseButtonUp(0))
        {
            if (_initialMousePos != Input.mousePosition)
            {
                _animator.SetTrigger("shoot");
            }
            else
            {
                _animator.SetTrigger("default");
                _lineRenderer.enabled = false;
            }

            _isCharging = false;
        }

        if (_isCharging)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            _dir = (mousePos - transform.position).normalized;
            _animator.SetFloat("slingshotX", _dir.x);
            _animator.SetFloat("slingshotY", _dir.y);
            _lineRenderer.SetPosition(1, -_dir * IndicatorLength);
        }
    }

    Vector3 GetMousePos() => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

    public void createrock()
    {
        OnSlingshot.Raise();
        GameObject stone = Instantiate(StonePrefab, transform.position, Quaternion.identity);
        stone.GetComponent<Stone>().Direction = -_dir;
        _lineRenderer.enabled = false;
    }
}
