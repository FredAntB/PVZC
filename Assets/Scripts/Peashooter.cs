using UnityEngine;
using System.Collections.Generic;

public class Peashooter : Plant
{
    public float attackCooldown;
    private float attackTime;

    public bool isAttacking;

    public GameObject Bullet;
    public GameObject Zombie;

    public void Start()
    {
        attackTime = 0;
        Zombie = null;
        isAttacking = false;
    }

    public void attack()
    {
        if (attackTime <= Time.time)
        {
            GameObject bullet = Instantiate(Bullet, transform.position + new Vector3(10f, 18f, 0f), Quaternion.identity, transform);
            bullet.GetComponent<Bullet>().SetDamage(Damage);
            attackTime = Time.time + attackCooldown;
        }
    }

    public void Update()
    {
        if (Health <= 0)
        {
            transform.parent.GetComponent<plantContainer>().isFull = false;
            Destroy(this.gameObject);
        }

        if (zombies.Count > 0 && !isAttacking)
        {
            Zombie = zombies[0];
            isAttacking = true;
        }
        else if (zombies.Count == 0 && isAttacking)
        {
            Zombie = null;
            isAttacking = false;
        }

        if (Zombie is not null)
        {
            attack();
        }
    }
}