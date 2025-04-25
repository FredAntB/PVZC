using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class ZombieMovement : MonoBehaviour
{
    public Image outer_arm_top;
    public Image outer_arm_bottom;
    public Image outer_hand;
    public Sprite half_arm;
    
    public int Health;
    public int Damage;
    public float Speed;
    private bool isEating;

    private Plant Food; // plant being eaten
    public float eatCooldown;
    public float lastTimeEaten;

    public Animator animator;


    private void Start()
    {
        isEating = false;
        lastTimeEaten = 0;
        Food = null;
    }

    public void Update() {
        if (animator.GetBool("isEating") != isEating)
        {
            animator.SetBool("isEating", isEating);
        }
        
        if (!isEating)
        {
            Food = null;
            transform.Translate(new Vector3(Speed * -1, 0f, 0f));
        }
        else if(Food != null && lastTimeEaten <= Time.time)
        {
            isEating = !Food.ReceiveDamage(Damage);
            lastTimeEaten = eatCooldown + Time.time;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // zombie collides with any object at layer 8 => plant
        if(collision.gameObject.layer == 8)
        {
            isEating = true;
            Food = collision.gameObject.GetComponent<Plant>();
        }
    }

    public abstract void ReceiveDamage(int Damage);
}
