using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject originalProjectile;
    public Transform castPosition;
    [SerializeField] float force = 100000f;
    bool canfire;
    // Start is called before the first frame update
    void Start()
    {
        canfire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canfire)
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
        canfire=true;   
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
    }
}
