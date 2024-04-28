using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion newQ = Quaternion.Euler(0, 0, 30f);

            transform.rotation *= newQ;
        }

        /*Vector3 direction = transform.position - target.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);

        transform.rotation = newRotation;*/
    }
}
