using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject originalProjectile;
    public Transform castPosition;
    [SerializeField] float force = 100000f;
    [SerializeField] GameObject sword;
    [SerializeField] GameObject swordcase;
    bool canfire,canattack;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        canfire = true;
        canattack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canfire)
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(0) 
            && (Input.GetKey(KeyCode.W) 
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S))
            &&canattack)
        {
            RunningAttack();
        }
        else if (Input.GetMouseButtonDown(0)&&canattack)
        {
            Attack();
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

    void Attack()
    {
        animator.SetTrigger("Attack");
        swordcase.SetActive(false);
        sword.SetActive(true);
        SetCooldown2(1.01f);
    }

    void SetCooldown()
    {
        canfire = false;
        Invoke("SetToReady", 1f);
    }
    void SetToReady()
    {
        canfire=true;   
        canattack=true;
    }
    void SetCooldown2(float f)
    {
        canattack = false;
        Invoke("SetToReady", f);
    }
    
    void Shoot()
    {
        //Vector3 orgin = transform.position + transform.forward * 0.5f + new Vector3(0, 1.5f, 0);
        //GameObject clone = Instantiate(originalProjectile, orgin, originalProjectile.transform.rotation);
        //Rigidbody cloneRig = clone.GetComponent<Rigidbody>();
        //Vector3 direction = Camera.main.transform.forward;
        //cloneRig.AddForce(direction * force);
        //Destroy(clone, 4f);
        GameObject clone = GameObject.Instantiate(originalProjectile, transform);
        clone.transform.position = castPosition.position - new Vector3(0,0,0.5f);
        clone.SetActive(true);
        clone.transform.parent = null;
        Destroy(clone, 4f);
        Vector3 direction = Camera.main.transform.forward;
        clone.GetComponent<Rigidbody>().AddForce(direction * force);
        SetCooldown();
    }
    void RunningAttack()
    {
        animator.SetTrigger("RunningAttack");
        sword.SetActive(true);
        swordcase.SetActive(false);
        SetCooldown2(0.8f);
    }
}
