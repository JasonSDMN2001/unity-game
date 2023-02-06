using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : health
{
    [Space]
    [Header("Playser Health properties")]
    [Space]
    [SerializeField]bool immune;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Animator animator;
    protected override void Start()
    {
        base.Start();
        immune = false;  
    }
    public override void TakeDamage(float dmg)
    {
        if (!alive) return;
        if (immune) return;
        currentHealth = Mathf.Max(currentHealth - dmg, 0f);
        healthBar.value = currentHealth/totalHealth;
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected override void Die()
    {
        base.Die();
        Debug.Log("Game Over");

        gameOverScreen.SetActive(true);
        animator.SetTrigger("Death");
        foreach (Component component in GetComponentsInChildren<Component>())
        {
            if(component.GetType()!= typeof(SkinnedMeshRenderer)
                && component.GetType()!= typeof(Transform)
                && component.GetType()!=typeof(Animator))
            {
                Destroy(component);
            }
        }
    }
    public void Heal(float value)
    {
        currentHealth = Mathf.Min(currentHealth + value,totalHealth);
        healthBar.value = currentHealth/totalHealth;
    }
}
