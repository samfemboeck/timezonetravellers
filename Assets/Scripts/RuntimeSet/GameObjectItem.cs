﻿using UnityEngine;

/*
 * You need this Script on every GameObject that you want to add to a Runtimeset.
 */
public class GameObjectItem : MonoBehaviour
{
    [SerializeField]
    public GameObjectSet set;

    void OnEnable()
    {
        set.Add(gameObject);
    }
}