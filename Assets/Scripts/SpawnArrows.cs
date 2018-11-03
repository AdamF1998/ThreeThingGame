using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrows : MonoBehaviour {

    public GameObject arrow;
    public float spawnTime;

    void Start()
    {
        spawnTime = Random.Range(1f, 2f);
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }



    // Update is called once per frame
    void Spawn()
    {
        Instantiate(arrow, transform.position, Quaternion.identity);
        spawnTime = Random.Range(1f, 4f);
    }
}
