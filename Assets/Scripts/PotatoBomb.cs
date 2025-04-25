using UnityEngine;
using System.Collections.Generic;

public class PotatoBomb : Plant
{   
    private bool isSleeping;
    public float sleepTime;
    private float startTime;

    public Animator animator;

    private ZombieMovement Zombie;

    protected void EraseAfterExplode()
    {
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        animator.SetTrigger("explode");
        Zombie.ReceiveDamage(Damage);
        Zombie = null;
    }

    public void Awake()
    {
        isSleeping = true;
        startTime = Time.time;
        Zombie = null;
    }

    public void Update()
    {
        if (!isSleeping && Zombie is not null)
        {
            Explode();
        }

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
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // zombie collides with any object at layer 9 => zombies
        if(collision.gameObject.layer == 9)
        {
            Zombie = collision.gameObject.GetComponent<ZombieMovement>();
            
            if (!isSleeping)
            {
                Explode();
            }
        }
    }
}
