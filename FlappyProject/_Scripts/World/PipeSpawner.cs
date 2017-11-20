using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    public GameObject Pipe;
    public float spawnInterval;
    public float spawnStartDelay;

    float spawnIntervalSet;

	// Use this for initialization
	void Start () {
        spawnIntervalSet = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameData.gameBegins) // Will only start spawning when the Game Begins
        {
            spawnStartDelay -= Time.deltaTime; // Decreases spawnStartDelay until it hits 0
            if (spawnStartDelay <= 0)
            {
                spawnIntervalSet -= Time.deltaTime; // Spawning begins. 
                if (spawnIntervalSet <= 0)
                {
                    Instantiate(Pipe, new Vector2(transform.position.x, Random.Range(-1.55f, 3f)), transform.rotation);
                    spawnIntervalSet = spawnInterval;
                }
            }
        }
	}
}
