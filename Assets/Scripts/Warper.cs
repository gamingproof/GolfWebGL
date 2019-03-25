using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour
{
    public Transform RespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Teleport(other);
    }


    private void OnTriggerEnter(Collider other)
    {
        Teleport(other);    
    }

    private void Teleport(Collider other)
    {
        other.transform.position = RespawnPoint.position;
        var rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
