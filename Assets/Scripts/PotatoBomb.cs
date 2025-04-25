using UnityEngine;
using System.Collections.Generic;

public class PotatoBomb : Plant
{   
    private bool isSleeping;
    public float sleepTime;
    private float startTime;

    public Animator animator;

    private ZombieMovement Zombie;

    public void Awake()
    {
        isSleeping = true;
        startTime = Time.time;
        Zombie = null;
    }

    public void Update()
    {
        if (Health <= 0)
        {
            transform.parent.GetComponent<plantContainer>().isFull = false;
            Destroy(this.gameObject);
        }

        if (sleepTime <= Time.time - startTime)
        {
            isSleeping = false;
            animator.SetBool("isSleeping", isSleeping);
        }

        if (!isSleeping && Zombie is not null)
        {
            Zombie.ReceiveDamage(Damage);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // zombie collides with any object at layer 9 => zombies
        if(collision.gameObject.layer == 9)
        {
            if (!isSleeping)
            {
                collision.gameObject.GetComponent<ZombieMovement>().ReceiveDamage(Damage);
                Destroy(this.gameObject);
            }
            else
            {
                Zombie = collision.gameObject.GetComponent<ZombieMovement>();
            }
        }
    }
}
