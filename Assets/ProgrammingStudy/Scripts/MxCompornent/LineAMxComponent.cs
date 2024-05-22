using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActUtlType64Lib;

public class LineAMxComponent : MonoBehaviour
{
    public static LineAMxComponent instance; // 싱글턴 객체
    public enum Connection
    {
        Connected,
        Disconnected,
    }
    ActUtlType64 mxComponent;

    public Connection connection = Connection.Disconnected;
    public LineACylinder cylinderA;
    public LineACylinder cylinderB;
    public LineASensor sensorA;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mxComponent = new ActUtlType64();
        mxComponent.ActLogicalStationNumber = 1;

        StartCoroutine(GetDevices());
    }

    private void Update()
    {
        GetDevices();
    }

   IEnumerator GetDevices()
    {
        while (true)
        {
            if (connection == Connection.Connected)
            {
                cylinderA.plcForwardValue = GetDevice(cylinderA.plcDeviceForwardAddress);
                cylinderA.plcBackwardValue = GetDevice(cylinderA.plcDeviceBackwardAddress);
                cylinderB.plcForwardValue = GetDevice(cylinderB.plcDeviceForwardAddress);
                cylinderB.plcBackwardValue = GetDevice(cylinderB.plcDeviceBackwardAddress);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    // PC 연결하기
    public void OnConnectPLCBtnClkEvent()
    {
        if (connection == Connection.Disconnected)
        {
            int returnValue = mxComponent.Open();
            if (returnValue == 0)
            {
                print("연결에 성공하였습니다.");

                connection = Connection.Connected;
            }
            else
            {
                print("연결에 실패했습니다. returnValue: 0x" + returnValue.ToString("X")); // 16진수로 변경
            }
        }
        else
        {
            print("연결 상태입니다.");
        }
    }

    // PC 연결 해제하기
    public void OnDisconnectPLCBtnClkEvent()
    {
        if (connection == Connection.Connected)
        {
            int returnValue = mxComponent.Close();
            if (returnValue == 0)
            {
                print("연결 해지되었습니다.");
                connection = Connection.Disconnected;
            }
            else
            {
                print("연결 해지에 실패했습니다. returnValue: 0x" + returnValue.ToString("X")); // 16진수로 변경
            }
        }
        else
        {
            print("연결 해지 상태입니다.");
        }
    }

    // 데이터를 보내기
    public bool SetDevice(string device, int data)
    {
        if (connection == Connection.Connected)
        {
            int returnValue = mxComponent.SetDevice(device, data);

            if (returnValue != 0)
            {
                print(returnValue.ToString("X"));
                return false;
            }

            return true;
        }
        else
            return false;
    }

    // 데이터를 받기
    public int GetDevice(string device)
    {
        if (connection == Connection.Connected)
        {
            int data = 0;
            int returnValue = mxComponent.GetDevice(device, out data);

            if (returnValue != 0)
                print(returnValue.ToString("X"));

            return data;
        }
        else
            return 0;
    }
}