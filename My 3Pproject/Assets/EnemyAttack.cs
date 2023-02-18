using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Enemy enemy;
    System.Random random;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();

    }
    private void Update()
    {
        random = new System.Random();
    }


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            enemy.AttackPlayer(random.Next(0, 4));
        }
    }
   
}
