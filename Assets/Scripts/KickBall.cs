using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KickBall : MonoBehaviour
{
    public bool IsStopped;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.magnitude <= 0f)
        {
            IsStopped = true;
        }
        else
        {
            IsStopped = false;
        }
    }

    public void Kick(float power, Vector3 direction)
    {
        rb.AddForce(direction * power, ForceMode.Impulse);
    }
}
