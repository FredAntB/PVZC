using UnityEngine;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour
{
    public List<GameObject> zombies;

    public void reduceZombieCountBy(int count)
    {
        transform.parent.GetComponent<zombieSpawner>().reduceZombieCountBy(count);
    }
}
