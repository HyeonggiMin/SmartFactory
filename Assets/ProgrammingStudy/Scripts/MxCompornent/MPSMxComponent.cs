using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActUtlType64Lib; // MX Component v5 Library 사용
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;


namespace MPS
{
    /// <summary>
    /// OpenPLC, ClosePLC
    /// </summary>
    public class MPSMxComponent : MonoBehaviour
    {
        enum Connection
        {
            Connected,
            Disconnected
        }

        ActUtlType64 mxComponent;
        Connection connection = Connection.Disconnected;

        public MeshRenderer redLamp;
        public MeshRenderer yellowLamp;
        public MeshRenderer greenLamp;

        public bool isCylinderMoving = false;

        void Start()
        {
            mxComponent = new ActUtlType64();
            mxComponent.ActLogicalStationNumber = 1;

            redLamp.material.color = Color.black;
            yellowLamp.material.color = Color.black;
            greenLamp.material.color = Color.black;

        }

        private void Update()
        {

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
                    print("연결에 실패하였습니다. returnValue: 0x" + returnValue.ToString("X")); // 16진수로 변경
                }

            }
            else
            {
                print("연결된 상태입니다.");
            }
        }

        public void OnDisConectBtnClkEvent()
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
                    print("연결 해지를 실패하였습니다. returnValue: 0x" + returnValue.ToString("X")); // 16진수로 변경
                }
            }
            else
            {
                print("연결 해지 상태입니다.");
            }
        }

        public Transform cyclinderA;
        public Transform cyclinderA_startPos;
        public Transform cyclinderA_endPos;

        public Transform cyclinderB;
        public Transform cyclinderB_startPos;
        public Transform cyclinderB_endPos;

        private void OnDestroy()
        {
            OnDisConectBtnClkEvent();
        }
    }
}


