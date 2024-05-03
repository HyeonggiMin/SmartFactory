using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPractice : MonoBehaviour
{
    public bool isObjectDetected = false; // flag ����, bool ����
    public bool isMetalObject = false;
    public MeshRenderer led;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            isObjectDetected = true;

            if (GetComponent<MeshRenderer>() != null && GetComponent<MeshRenderer>().isVisible)
            {
                GetComponent<MeshRenderer>().material.color = Color.green;
            }

            if (this.gameObject.layer == LayerMask.NameToLayer("Destination"))
            {
                print(this.gameObject.name);
            }
        }

        AudioManager.instance.PlayAudioClip(clip);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("MetalObject"))
        {
            isMetalObject = true;
            print("MetalObject ����");
        }
        /*  else
        {
            isMetalObject = false;
            print("NonMetalObject ����");
        }*/

        led.material.color = Color.green;
        isObjectDetected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        led.material.color = Color.white;
        isObjectDetected = false;

    }
}