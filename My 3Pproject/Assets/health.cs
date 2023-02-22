using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]protected float currentHealth;
    [SerializeField]protected float totalHealth = 100f;
    [SerializeField]protected bool alive;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = totalHealth;
        alive = true;
    }
    public virtual void TakeDamage(float dmg)
    {
        if(!alive)return;
        currentHealth= Mathf.Max(currentHealth - dmg,0f);
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        alive = false;
    }
}
