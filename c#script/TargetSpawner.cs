using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int targetCount = 5;
    public Vector3 spawnAreasize = new Vector3(10, 10, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < targetCount; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
              Random.Range(-spawnAreasize.x / 2, spawnAreasize.x / 2),
              Random.Range(-spawnAreasize.y / 2, spawnAreasize.y / 2),
              Random.Range(-spawnAreasize.z / 2, spawnAreasize.z / 2));

            Instantiate(targetPrefab, randomPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    }
