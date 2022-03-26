using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float cooldown = 0;
    float spawnTime = 0;

    Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if(cooldown >= spawnTime)
        {
            spawnTime = Random.Range(0, 3);
            cooldown = 0;
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = new Vector3(Random.Range(coll.bounds.min.x, coll.bounds.max.x),
                                                   Random.Range(coll.bounds.min.y, coll.bounds.max.y),
                                                   Random.Range(coll.bounds.min.z, coll.bounds.max.z));
            Destroy(enemy, 20);
        }
    }
}
