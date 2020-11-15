using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCorrupt : MonoBehaviour
{
    public Sprite SpriteBad;

    public void GoCurrupt()
    {
        GetComponent<SpriteRenderer>().sprite = SpriteBad;
    }
}
