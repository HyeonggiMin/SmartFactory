using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시작시 Player가 뒤 방향으로 이동한다.
public class Cylinder : MonoBehaviour
{
    public float speed = 2;
    public float distanceLimit = 0.3f;
    public float startTime = 2;
    public Transform destination;
    public Sensor sensor;
    public Timer timer;
    float currentTime;
    float arrivalTime;
    

    void Start()
    {

    }


    void Update() // 프레임이 갱신될 때 실행되는 매서드 0.002 ~ 0.004에 한번씩 이동
    {
        if (sensor.isObjectDetected)
        {
            Vector3 direction = Vector3.back;

            currentTime += Time.deltaTime;
            if (currentTime > startTime)
            {
                // 현 위치에서부터 destination까지의 벡터
                Vector3 dir2Dest = (destination.position - transform.position).normalized;
                float distance = (destination.position - transform.position).magnitude;

                if (distance > distanceLimit)
                {
                    transform.position += dir2Dest * Time.deltaTime * speed;
                }
                else
                {
                    sensor.isObjectDetected = false;
                    GetComponent<Rigidbody>().velocity = Vector3.zero;

                    // 도착 시 알림
                    arrivalTime = timer.currentTime;
                    print("도착시간: " + arrivalTime);
                    currentTime = 0;
                }
            }
        }
    }

    // 충돌이 시작되었을 때 실행되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "에 충돌했습니다.");
        }
    }

    // 충돌이 진행 중 실행되는 함수
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "에 붙어있습니다.");
        }
    }

    // 충돌이 끝났을 때 실행되는 함수
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + " 충돌이 끝났습니다.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print("OnTriggerEnter");
        }
    }
}

