using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();

    }
    


    private void OnTriggerStay(Collider other)
    {
        System.Random random = new System.Random();
        if (other.CompareTag("Player"))
        {
            
            enemy.AttackPlayer(random.Next(0, 4));
        }
    }
   
}
