﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public int totalBalloons;
    public int currentballoons;
    public GameObject[] BalloonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentballoons = totalBalloons;
        for (int i = 0; i < totalBalloons; i++)
            Instantiate(BalloonPrefab[Random.Range(0,BalloonPrefab.Length)], Map.Instance.GetRandomPosition(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
