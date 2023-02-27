using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }
    public void DealDamage(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            health foundHealth = other.GetComponentInParent<health>();
            if (foundHealth != null)
            {
                foundHealth.TakeDamage(damage);
            }
        }
    }
}
