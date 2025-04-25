using UnityEngine;
using System.Collections.Generic;

public class zombieSpawner : MonoBehaviour
{
    public List<GameObject> zombiePrefabs;
    public List<Zombie> zombies;

    public int zombieCount;

    public void reduceZombieCountBy(int count)
    {
        zombieCount -= count;
    }

    public void Update() {
        foreach(Zombie zombie in zombies) {
            if (!zombie.isSpawned && zombie.spawnTime <= Time.time)
            {
                Transform spawner = transform.GetChild(zombie.Spawner).transform;
                GameObject zombieInstance = Instantiate(zombiePrefabs[(int)zombie.type], spawner.position + new Vector3(0f, 50f, 0f), Quaternion.identity, spawner);
                zombie.isSpawned = true;
                transform.GetChild(zombie.Spawner).GetComponent<SpawnPoint>().zombies.Add(zombieInstance);
                
                    zombieCount++;
            }
        }
    }
}