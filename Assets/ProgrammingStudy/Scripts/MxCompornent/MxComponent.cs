using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActUtlType64Lib; // MX Component v5 Library ���
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;


/// <summary>
/// OpenPLC, ClosePLC
/// </summary>
public class MxComponent : MonoBehaviour
{
    enum Connection
    {
        Connected,
        Disconnected
    }

    ActUtlType64 mxComponent;
    Connection connection = Connection.Disconnected;
    //public Button readButton;
    public TMP_InputField deviceInput;
    public TMP_InputField valueInput;
    public TMP_Text log;

    public MeshRenderer redLamp;
    public MeshRenderer yellowLamp;
    public MeshRenderer greenLamp;
    public MeshRenderer redLamp_Person;
    public MeshRenderer greenLamp_Person;

    public bool isCylinderMoving = false;

    void Start()
    {
        mxComponent = new ActUtlType64();
        mxComponent.ActLogicalStationNumber = 1;

        //readButton.onClick.AddListener(OnDisConectBtnClkEvent);
        //readButton.onClick.AddListener(() => OnReadDataBtnClkEvent(deviceInput, valueInput));

        redLamp.material.color = Color.black;
        yellowLamp.material.color = Color.black;
        greenLamp.material.color = Color.black;
        redLamp_Person.material.color = Color.black;
        greenLamp_Person.material.color = Color.black;
    }

    private void Update()
    {
        /* //��ȣ�� ����
          if(connection == Connection.Connected)
                {
                    int valueRed = GetDevice("M100");
                    if (valueRed != 0)
                    {
                        redLamp.material.color = Color.red;
                        yellowLamp.material.color = Color.black;
                        greenLamp.material.color = Color.black;
                    }

                    int valueYellow = GetDevice("M101");
                    if (valueYellow != 0)
                    {
                        redLamp.material.color = Color.black;
                        yellowLamp.material.color = Color.yellow;
                        greenLamp.material.color = Color.black;
                    }

                    int valueGreen = GetDevice("M102");
                    if (valueGreen != 0)
                    {
                        redLamp.material.color = Color.black;
                        yellowLamp.material.color = Color.black;
                        greenLamp.material.color = Color.green;
                    }
                }*/

        /* //�ǽ�1
         * int motor0 = GetDevice("M0");
        int timer0 = GetDevice("T0");
        int motor1 = GetDevice("M1");
        int timer1 = GetDevice("T1");

        log.text = $"Motor: {motor0}, Timer: {timer0}\n" +
                   $"Motor1: {motor1}, Timer:{timer1}";*/

        /*        //�ǽ�2
        int redLampValue = GetDevice("M1");
        int yellowLampValue = GetDevice("M2");
        int greenLampValue = GetDevice("M3");
        

        if(redLampValue == 1)
        {
            redLamp.material.color = Color.red;
        }
        else
        {
            redLamp.material.color = Color.black;
        }
        if (yellowLampValue == 1)
        {
           yellowLamp.material.color = Color.yellow;
        }
        else
        {
            yellowLamp.material.color = Color.black;
        }
        if (greenLampValue == 1)
        {
            greenLamp.material.color= Color.green;
        }
        else
        {
            greenLamp.material.color = Color.black;
        }*/

        /*        // �ǽ�3
        int redLampValue = GetDevice("Y0");
        int cylinderFW = GetDevice("Y1");
        int cylinderBW = GetDevice("Y2");

        if(redLampValue == 1)
        {
            redLamp.material.color = Color.red;

        }
        else
        {
            redLamp.material.color = Color.black;
        }

        if(cylinderFW == 1 && !isCylinderMoving)
        {
            //StartCoroutine(MoveCylinder(cylinderA, cylinderA_start.position, cylinderA_end.position,1));
        }

        if(cylinderBW == 1 && !isCylinderMoving)
        {
            //StartCoroutine(MoveCylinder(cylinderA, cylinderA_end.position, cylinderA_start.position, 1));
        }*/

        // �ǽ�4 ����, ������ ��ȣ��
        int green_vehicle = GetDevice("Y0");
        int yellow_vehicle = GetDevice("Y1");
        int red_vehicle = GetDevice("Y2");
        int green_people = GetDevice("Y10");
        int red_people = GetDevice("Y11");

        if(green_vehicle == 1)
        {
            greenLamp.material.color = Color.green;
            yellowLamp.material.color = Color.black;
            greenLamp.material.color = Color.black;

            redLamp_Person.material.color = Color.red;
            greenLamp_Person.material.color = Color.black;

        }

        if(yellow_vehicle == 1)
        {
            yellowLamp.material.color = Color.yellow;
            greenLamp.material.color = Color.black;
            redLamp.material.color = Color.black;
        }

        if (red_vehicle == 1)
        {
            redLamp.material.color = Color.red;
            greenLamp.material.color = Color.black;
            yellowLamp.material.color = Color.black;

            greenLamp_Person.material.color = Color.green;
            redLamp_Person.material.color = Color.black;
        }
    }

    int GetDevice(string device)
    {
        if (connection == Connection.Connected)
        {
            int lampData = 0;
            int returnValue = mxComponent.GetDevice(device, out lampData);
            if (returnValue != 0)
                print(returnValue.ToString("X"));

            return lampData;
        }
        else
            return 0;
    }

    public void OnConectBtnClkEvent()
    {
        if(connection == Connection.Disconnected)
        {
            int returnValue = mxComponent.Open();
            if (returnValue == 0)
            {
                print("���ῡ �����Ͽ����ϴ�.");
                
                connection = Connection.Connected;
            }
            else
            {
                print("���ῡ �����Ͽ����ϴ�. returnValue: 0x" + returnValue.ToString("X")); // 16������ ����
            }

        }
        else
        {
            print("����� �����Դϴ�.");
        }
    }

    public void OnDisConectBtnClkEvent()
    {
        if(connection == Connection.Connected)
        {
            int returnValue = mxComponent.Close();
            if (returnValue == 0)
            {
                print("���� �����Ǿ����ϴ�.");

                connection = Connection.Disconnected;
            }
            else
            {
                print("���� ������ �����Ͽ����ϴ�. returnValue: 0x" + returnValue.ToString("X")); // 16������ ����
            }
        }
        else
        {
            print("���� ���� �����Դϴ�.");
        }
    }

    public void OnReadDataBtnClkEvent()

    {
        if(connection == Connection.Connected)
        {
            int data = 0;

            int returnValue = mxComponent.GetDevice("M0", out data);
            if (returnValue != 0)
                print("returnValue: 0x" + returnValue.ToString("X"));
            else
                log.text = $"M0: {data}";
        }
    }

    public void OnReadDataBtnClkEvent(TMP_InputField deviceInput, TMP_InputField deviceValue)

    {
        if (connection == Connection.Connected)
        {
            int data = 0;

            int returnValue = mxComponent.GetDevice(deviceInput.text, out data);
            if (returnValue != 0)
                print("returnValue: 0x" + returnValue.ToString("X"));
            else
            {
                log.text = $"{deviceInput.text}: {data.ToString("X")}";
                deviceValue.text = data.ToString("X");
            }
        }
    }

    public void OnWriteDataBtnClkEvent()
    {
        if (connection == Connection.Connected)
        {
            int returnValue = mxComponent.SetDevice("M0", 1);
            if (returnValue != 0)
                print("returnValue: 0x" + returnValue.ToString("X"));
            else
                log.text = $"M0: 1";
        }
    }

    public void OnWriteDataBtnClkEvent(TMP_InputField deviceInput, TMP_InputField deviceValue)
    {
        if (connection == Connection.Connected)
        {
            int value = int.Parse(deviceValue.text);
            int returnValue = mxComponent.SetDevice(deviceValue.text, value);
            if (returnValue != 0)
                print("returnValue: 0x" + returnValue.ToString("X"));
            else
                log.text = $"{deviceInput.text}: {value}";
        }
    }

    public void OnReadDataBlockBtnClkEvent(TMP_InputField deviceInput, TMP_InputField deviceValue)
    {
        if (connection == Connection.Connected)
        {
            int size = 10;
            short data = 0;

            int returnValue = mxComponent.ReadDeviceBlock2(deviceInput.text, size, out data);
            if (returnValue != 0)
                print("returnValue: 0x" + returnValue.ToString("X"));
            else
                log.text = $"{deviceInput.text}: {data}";
        }
    }

    public Transform cyclinderA;
    public Transform cyclinderA_startPos;
    public Transform cyclinderA_endPos;

    public Transform cyclinderB;
    public Transform cyclinderB_startPos;
    public Transform cyclinderB_endPos;

    IEnumerator CoListner()
    {
        while(true)
        {
            int value = GetDevice("Y0");

            if (value == 1)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        //yield return MoveCylinder(cyclinderA,cyclinderA_startPos,Position, cyclinderA_end position,1);
    }

    private void OnDestroy()
    {
        OnDisConectBtnClkEvent();
    }
}
