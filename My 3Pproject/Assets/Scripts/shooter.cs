using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
   
   
    
    [SerializeField] GameObject sword;
    [SerializeField] GameObject swordcase;
    bool canattack;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        canattack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) 
            && (Input.GetKey(KeyCode.W) 
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S))
            &&canattack)
        {
            RunningAttack();
        }
        else if (Input.GetMouseButtonDown(0) && canattack)
        {
            System.Random random = new System.Random();
            Attack(random.Next(0, 7));
        }
        if (Input.GetKey(KeyCode.H))
        {
            sword.SetActive(false);
            swordcase.SetActive(true);
        }
        if (Input.GetKey(KeyCode.G))
        {
            sword.SetActive(true);
            swordcase.SetActive(false);
        }

    }

    void Attack(int i)
    {
        switch (i)
        {
            case 0:
                animator.SetTrigger("Attack");
                break; 
            case 1:
                animator.SetTrigger("Attack2");
                break;
            case 2:
                animator.SetTrigger("Attack3");
                break;
            case 3:
                animator.SetTrigger("Attack4");
                break;
            case 4:
                animator.SetTrigger("Attack5");
                break;  
            case 5:
                animator.SetTrigger("Attack6");
                break;
            case 6:
                animator.SetTrigger("Attack7");
                break;
        }
        swordcase.SetActive(false);
        sword.SetActive(true);
        SetCooldown2(1.01f);
    }

    void SetCooldown()
    {
        Invoke("SetToReady", 1f);
    }
    void SetToReady()
    {
        canattack=true;
    }
    void SetCooldown2(float f)
    {
        canattack = false;
        Invoke("SetToReady", f);
    }
    
    
    void RunningAttack()
    {
        animator.SetTrigger("RunningAttack");
        sword.SetActive(true);
        swordcase.SetActive(false);
        SetCooldown2(0.8f);
    }
}
