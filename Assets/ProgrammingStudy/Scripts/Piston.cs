using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static JSONSeriallization.Person;

public class Piston : MonoBehaviour
{
    public Transform pistonRod;
    public Transform switchForward;
    public Transform switchBackward;
    public Image forwardButtonImg;
    public Image backwardButtonImg;
    public SensorPractice sensor;
    public float minRange;
    public float maxRange;
    public float runTime = 2;
    float elapsedTime = 0;
    bool isForward = true;
    Vector3 minPos;
    Vector3 maxPos;
    public AudioClip clip;
    public int plcinputNumber; // Input�� ����
    public int[] plcinputValues; // ����� ��� �Է� 1��, ����� ��� �Է� 2��
    
    void Start()
    {
        DeviceInfo info = new DeviceInfo("����Ǹ���", "�Ǹ���A", 55555, 5555, "2024.05.30", "2026.06.30");
        JSONSeriallization.Instance.devices.Add(info);
        AudioManager.instance.PlayAudioClip(clip);

        SetCylinderBtnActive(!isForward, true);
        SetCylinderSwitchActive(!isForward, true);

        minPos = new Vector3(pistonRod.transform.localPosition.x, minRange, pistonRod.transform.localPosition.z);
        maxPos = new Vector3(pistonRod.transform.localPosition.x, maxRange, pistonRod.transform.localPosition.z);

        plcinputValues = new int[plcinputNumber];
    }

    public void MovePistonRod(Vector3 startPos, Vector3 endPos, float _elapsedTime, float _runTime)
    {
        Vector3 newPos = Vector3.Lerp(startPos, endPos, _elapsedTime / _runTime); // t���� 0(minPos) ~ 1(maxPos)�� ��ȭ
        pistonRod.transform.localPosition = newPos;
    }

    public void OnDischargeObjectBtnEvent()
    {
        print("�۵�!");
        if (sensor != null && sensor.isMetalObject)
        {
            print("���� �Ϸ�");
            OnCylinderButtonClickEvent(true);
        }
    }

    // PistonRod�� Min, Max ����
    // ����: LocalTransform.position.y�� - 0.3 ~ 1.75 ���� �̵�
    public void OnCylinderButtonClickEvent(bool direction)
    {
        StartCoroutine(CoMove(direction));
    }

    IEnumerator CoMove(bool direction)
    {
        SetButtonActive(false);
        SetCylinderBtnActive(direction, true);
        SetCylinderSwitchActive(direction, false);

        float elapsedTime = 0;

        while (elapsedTime < runTime)
        {
            elapsedTime += Time.deltaTime;

            if (direction == isForward)
            {
                print(name + " ������...");

                forwardButtonImg.color = Color.green;

                MovePistonRod(minPos, maxPos, elapsedTime, runTime);
            }
            else
            {
                print(name + " ������...");

                backwardButtonImg.color = Color.green;

                MovePistonRod(maxPos, minPos, elapsedTime, runTime);
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

        SetButtonActive(true);
    }

    private void SetCylinderSwitchActive(bool direction, bool isActive)
    {
        if (isActive)
        {
            if (direction != isForward)
            {
                switchBackward.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                switchForward.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
        else
        {
            switchForward.GetComponent<MeshRenderer>().material.color = Color.white;
            switchBackward.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    void SetCylinderBtnActive(bool direction, bool isActive)
    {
        if (direction == isForward)
        {
            forwardButtonImg.color = Color.green;
            backwardButtonImg.color = Color.white;
        }
        else
        {
            forwardButtonImg.color = Color.white;
            backwardButtonImg.color = Color.green;
        }
    }

    void SetButtonActive(bool isActive)
    {
        forwardButtonImg.GetComponent<Button>().interactable = isActive;
        backwardButtonImg.GetComponent<Button>().interactable = isActive;
    }
}
