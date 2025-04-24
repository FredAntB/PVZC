using UnityEngine;

[System.Serializable]
public class Zombie
{
    public int spawnTime;
    public ZombieType type;
    public int Spawner;
    public bool randomSpawner;
    public bool isSpawned;

}

public enum ZombieType {
    ZombieCommon,
    ZombieCone,
    ZombieBucket
};
