using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieSpawner : MonoBehaviour
{
    public Transform target;
    public GameObject zombiePrefab;
    public float minAmount = 0, maxAmount = 20;
    public float spawnRate = 1f;
    delegate GameObject ClosestFunc(Vector3 position);
    ClosestFunc findClosest;

    void Start()
    {
        //StartCoroutine(ZombieSpawn());
        InvokeRepeating("SpawnZombie", 1, 5);
    }

    void Update()
    {
        
    }

    void SpawnZombie()
    {
        // SetTarget on zombie to target
        GameObject clone = Instantiate(zombiePrefab, transform.position, transform.rotation);
        // Referring to the Enemy script
        Zombie zombie = clone.GetComponent<Zombie>();
        // Get closest player to zombie
        GameObject player = FindClosestPlayer(zombie.transform.position);
        // Telling the enemy what the target is
        zombie.SetTarget(player.transform);
    }

    IEnumerator ZombieSpawn()
    {
        yield return new WaitForSeconds(1);
        // Grabbing clone we just spawned
        GameObject clone = Instantiate(zombiePrefab, transform.position, transform.rotation);
        // Referring to the Enemy script
        Zombie zombie = clone.GetComponent<Zombie>();
        // Get closest player to zombie
        GameObject player = FindClosestPlayer(zombie.transform.position);
        // Telling the enemy what the target is
        zombie.SetTarget(player.transform);
    }

    // SetTarget to target
    GameObject FindClosestPlayer(Vector3 position)
    {
        Player[] players = FindObjectsOfType<Player>();
        float minDistance = float.MaxValue;
        GameObject closest = null;
        for (int i = 0; i < players.Length; i++)
        {
            Vector3 playerPos = players[i].transform.position;
            float distance = Vector3.Distance(playerPos, position);
            if (distance <= minDistance)
            {
                distance = minDistance;
                closest = players[i].gameObject;
            }
        }
        return closest;
    }
}


