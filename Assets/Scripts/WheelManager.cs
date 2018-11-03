using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour {

    public GameObject wheel;
    public float spawnTime = 3f;            
                                         
    void Start () {

        InvokeRepeating("Spawn", spawnTime, spawnTime);

	}
	
	// Update is called once per frame
	void Spawn () {
        Instantiate(wheel, transform.position, transform.rotation);
    }
}
