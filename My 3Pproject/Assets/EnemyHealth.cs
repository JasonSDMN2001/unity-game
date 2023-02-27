using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : health
{
    private Spawner myParentSpawner;
    public Slider healthBar;
    public Animator animator;
    public GameObject[] loots;
    public float force;
    protected override void Start()
    {
        base.Start();
        UpdateUI();
    }
    public void RegisterSpawner(Spawner myParentSpawner)
    {
        this.myParentSpawner = myParentSpawner;
    }

    protected override void Die()
    {
        base.Die();
        myParentSpawner.NotifyDeath(this);
        animator.SetTrigger("Death");
        enabled = false;
        //Remove logic
        GetComponentInParent<Enemy>().enabled = false;
        GetComponentInParent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
        GetComponentInParent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        foreach(Collider collider in GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }
        Destroy(GetComponentInChildren<Canvas>());
        //Destroy(gameObject);
        Invoke("DestroyEnemy", 100f);
        DropLoot();
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        UpdateUI();
        animator.SetTrigger("Hit");
    }
    void UpdateUI()
    {
        healthBar.value = currentHealth/totalHealth;
    }
    void DropLoot()
    {
        foreach(GameObject item in loots)
        {
            Quaternion randomRot = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            GameObject clone = Instantiate(item,transform.position,randomRot);
            Vector3 randomExplosionPos = clone.transform.position;
            randomExplosionPos.x += Random.Range(-0.01f, 0.01f);
            randomExplosionPos.y += Random.Range(-0.01f, 0.01f);
            randomExplosionPos.z += Random.Range(-0.01f, 0.01f);
            clone.GetComponent<Rigidbody>().AddExplosionForce(force, randomExplosionPos, force, 0f, ForceMode.Impulse);
        }
    }
}
