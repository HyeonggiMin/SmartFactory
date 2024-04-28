using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAndTorque : MonoBehaviour
{
    public float force = 20f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 dir = transform.up;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 dir = Vector3.up;
            rb.AddForce(dir * force);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float turn = Input.GetAxis("Horizontal");

            rb.AddTorque(dir * force * turn);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
