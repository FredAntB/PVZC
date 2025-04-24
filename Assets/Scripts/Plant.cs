using UnityEngine;
using System.Collections.Generic;

public abstract class Plant : MonoBehaviour
{
    public int Health;
    public int Damage;
    public List<GameObject> zombies;

    public void ReceiveDamage(int damage)
    {
        Health -= damage;
    }
}
