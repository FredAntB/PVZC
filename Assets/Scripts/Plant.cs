using UnityEngine;
using System.Collections.Generic;

public abstract class Plant : MonoBehaviour
{
    public int Health;
    public int Damage;
    public List<GameObject> zombies;

    public abstract void attack();
}
