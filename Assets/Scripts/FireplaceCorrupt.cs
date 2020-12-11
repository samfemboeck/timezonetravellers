using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceCorrupt : MonoBehaviour
{
    public Sprite SpriteCorrupt;

    public void GoCorrupt()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = SpriteCorrupt;
    }
}
