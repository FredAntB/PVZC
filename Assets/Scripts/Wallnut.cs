using UnityEngine;
using UnityEngine.UI;

public class Wallnut : Plant
{
    public Image wallnutImage;
    public Sprite walnutCracked;
    public Sprite walnutFinalCrack;

    public void Update()
    {
        if (Health <= 0)
        {
            transform.parent.GetComponent<plantContainer>().isFull = false;
            Destroy(this.gameObject);
        }
        else if(Health <= 140 )
        {
            wallnutImage.sprite = walnutCracked;
        }
        else if(Health <= 80)
        {
            wallnutImage.sprite = walnutFinalCrack;
        }
    }
}
