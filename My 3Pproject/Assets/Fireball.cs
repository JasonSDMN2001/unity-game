using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 200f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        health health1 = collision.gameObject.GetComponent<health>(); 
        if (health1 != null)
        {
            health1.TakeDamage(damage);
        }
    }
}
