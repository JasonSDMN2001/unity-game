using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xp : MonoBehaviour
{
    private Transform target=null;
    [SerializeField] private float speed=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            transform.position = Vector3.Lerp(transform.position, target.position + Vector3.up, Time.deltaTime*speed);
            if (Vector3.Distance(transform.position, target.position) < 0.2f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            GetComponent<MeshCollider>().enabled=false;
        }
    }
}
