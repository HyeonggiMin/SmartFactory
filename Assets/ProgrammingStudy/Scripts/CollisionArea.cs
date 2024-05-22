using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("Enter Collision: " +  collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        print("CollisionStray: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        print("CollisionExit: " + collision.gameObject.name);
    }
}
