using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shooter2 : MonoBehaviour
{
    public GameObject originalProjectile;
    bool canfire;
    public Transform castPosition;
    [SerializeField] float force;
    [SerializeField] Animator animator;
    public Vector3 projectileGlobalScale = new Vector3 (1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        canfire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canfire)
        {
            Shoot();
        }

    }
    void SetCooldown()
    {
        canfire = false;
        Invoke("SetToReady", 1f);
    }
    void SetToReady()
    {
        canfire = true;
    }
    void Shoot()
    {
        animator.SetTrigger("Fireball");
        //Vector3 orgin = transform.position + transform.forward * 0.5f + new Vector3(0, 1.5f, 0);
        //GameObject clone = Instantiate(originalProjectile, orgin, originalProjectile.transform.rotation);
        //Rigidbody cloneRig = clone.GetComponent<Rigidbody>();
        //Vector3 direction = Camera.main.transform.forward;
        //cloneRig.AddForce(direction * force);
        //Destroy(clone, 4f);
        GameObject clone = GameObject.Instantiate(originalProjectile, transform);
        //clone.transform.position = castPosition.position - new Vector3(0, 0, 0.2f);
        clone.SetActive(true);
        clone.transform.parent = null;
        clone.transform.localScale = projectileGlobalScale; 
        Destroy(clone, 15f);
        Vector3 direction = Camera.main.transform.forward+new Vector3(0,0.2f,0);
        clone.transform.position += direction;
        clone.GetComponent<Rigidbody>().AddForce(direction * force);
        SetCooldown();
    }
}
