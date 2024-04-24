using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    void Start()
    {
        // 6. IF, Switch 조건문

        bool isActive = true;

        if (isActive)
        {
            print("작동 중입이다.");
        }
        else
        {
            print("정지상태입니다.");
        }

        // 비교 연산자
        int number = 5;
        if (number == 0) print("");
        else if (number != 0) print("");
        else if (number > 0) print("");
        else if (number < 0) print("");
        else if (number >= 0) print("");
        else if (number <= 0) print("");

        // 논리 연산자 AND(&&), OR(||), NOT(!)
        if (number == 0 && isActive == true) print("");
        else if (number == 0 || isActive == false) print("");
        else if (!isActive) print("");

        // 번호에 따른 시퀀스 작동
        int status = 0;

        switch (status)
        {
            case 0:
                print("0번 상태입니다.");
                break;
            case 1:
                print("1번 상태입니다.");
                break;
            case 2:
                print("2번 상태입니다.");
                break;
        }

        // PLC 5초 딜레이 신호등을 if문 또는 switch case문으로 작성해 봅니다.
        // 조건: status / 적색(0), 황색(1), 녹색(2)
        // M10(0), M11(1), M12(2) -> print("황색 전구 ON");
        // Timer -> print("5초 Timer On");

        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                print("적색 전구 ON");
            }
            if (i == 1)
            {
                print("황색 전구 ON");
            }
            if (i == 2)
            {
                print("녹색 전구 ON");
            }

            print("5초 Timer On");
        }
    }


    void Update()
    {
        
    }
}
