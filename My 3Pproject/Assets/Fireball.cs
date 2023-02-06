using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 200f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        health heAlth = collision.gameObject.GetComponent<health>(); 
        if (heAlth != null)
        {
            heAlth.TakeDamage(damage);
        }
    }
}
