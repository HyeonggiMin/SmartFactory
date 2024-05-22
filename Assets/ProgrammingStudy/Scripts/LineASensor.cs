using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineASensor : MonoBehaviour
{
    public string plcAddress;
    public int plcValue;
    public Transform box;
    Vector3 originPos;
    Quaternion originRot;
    public bool isEndSensor = false;

    private void Start()
    {
        originPos = box.position;
        originRot = box.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Box"))
        {
            LineAMxComponent.instance.SetDevice(plcAddress, 1);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Box"))
        {
            Rigidbody rb = other.transform.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (isEndSensor)
            {
                // SensorB

                other.transform.position = originPos;
                other.transform.rotation = originRot;
                return;
            }

            // SensorA
            LineAMxComponent.instance.SetDevice(plcAddress, 1);
        }
    }
}
