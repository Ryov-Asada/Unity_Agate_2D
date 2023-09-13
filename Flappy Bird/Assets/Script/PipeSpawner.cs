﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float ymin,ymax;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

   IEnumerator SpawnPipeCoroutine()
   {
    yield return new WaitForSeconds(spawnTime);
    Instantiate(pipe,transform.position + Vector3.up*Random.Range(ymin,ymax),Quaternion.identity);
    StartCoroutine(SpawnPipeCoroutine());
   }
}
