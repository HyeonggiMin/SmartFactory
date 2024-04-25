using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간의 경과를 특정 변수에 저장한다.
public class Timer : MonoBehaviour
{
    public float currentTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        //print("경과 시간: " + currentTime);
    }
}
