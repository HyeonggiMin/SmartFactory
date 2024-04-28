using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;


// 실습1. time.deltaTime과 Quaternion을 이용한 을 이용한 시계 만들기
// Start함수에서 DateTime.Now로 현재시간 초기화
public class Clock : MonoBehaviour
{
    public float timeScale = 1;
    public Transform hourHand;
    public Transform minHand;
    public Transform secHand;
    public int hour = 0;
    public int minute = 0;
    public int second = 0;
    float currentTime = 0;
    float currentTimeForSec = 0;
    int angleHour = 0;
    int angleMin = 0;
    int angleSec = 0;
    int secAngleMount = 6; // 360 / 60
    int minAngleMount = 6; // 360 / 60
    int hourAngleMount = 30; // 360 / 12
    bool is24Hours = false;

    void Start()
    {
        print("시작시간 " + DateTime.Now);

        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;

        currentTime = second;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;

        ElapseTime();

        RotateClockHandsByTime();
    }

    private void RotateClockHandsByTime()
    {
        currentTimeForSec += Time.deltaTime;

        if (currentTimeForSec >= 1)
        {
            currentTimeForSec = 0;

            angleSec = second * secAngleMount;
            angleMin = minute * minAngleMount;
            angleHour = hour * hourAngleMount;

            print($"현재시간: {hour}:{minute}:{second}");
            print($"시계바늘 각도: {angleHour}/{angleMin}/{angleSec}");

            hourHand.transform.rotation = Quaternion.Euler(0, 0, -angleHour);
            minHand.transform.rotation = Quaternion.Euler(0, 0, -angleMin);
            secHand.transform.rotation = Quaternion.Euler(0, 0, -angleSec);

            hourHand.transform.localRotation = Quaternion.Euler(0, 0, -angleHour);
            minHand.transform.localRotation = Quaternion.Euler(0, 0, -angleMin);
            secHand.transform.localRotation = Quaternion.Euler(0, 0, -angleSec);
        }
    }

    private void ElapseTime()
    {
        currentTime += Time.deltaTime;
        second = (int)currentTime;

        if (second > 59)
        {
            currentTime = 0;
            second = 0;
            minute++;
        }

        if (minute > 59)
        {
            minute = 0;
            hour++;

            if (is24Hours)
            {
                if (hour > 24)
                {
                    hour = 1;
                }
            }
            else
            {
                if (hour > 12)
                {
                    hour = 1;
                }
            }
        }
    }
}