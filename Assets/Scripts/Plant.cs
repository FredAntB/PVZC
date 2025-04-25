using UnityEngine;
using System.Collections.Generic;

public abstract class Plant : MonoBehaviour
{
    public int Health;
    public int Damage;
    public List<GameObject> zombies;

    public bool ReceiveDamage(int damage)
    {
        Health -= damage;
        return Health <= 0;

    }
}
