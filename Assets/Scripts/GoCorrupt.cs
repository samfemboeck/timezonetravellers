using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCorrupt : MonoBehaviour
{
    bool _isCorrupt = false;
    public Sprite SpriteBad;
    public Sprite SpriteGood;
    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Toggle()
    {
        if (_isCorrupt)
            GetComponent<SpriteRenderer>().sprite = SpriteGood;
        else
            GetComponent<SpriteRenderer>().sprite = SpriteBad;

        _isCorrupt = !_isCorrupt;
    }
}
