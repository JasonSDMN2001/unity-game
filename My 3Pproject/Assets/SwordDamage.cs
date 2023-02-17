using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] public float damage;
    
    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);         
    }
    public void DealDamage(GameObject other)
    {
        if (!other.CompareTag("Player"))
        {
            health enemyHealth = other.gameObject.GetComponent<health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
