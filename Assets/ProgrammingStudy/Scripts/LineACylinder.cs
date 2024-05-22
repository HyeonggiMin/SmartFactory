using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineACylinder : MonoBehaviour
{
    public string plcDeviceForwardAddress; // Y0
    public string plcDeviceBackwardAddress; // Y0
    public int plcForwardValue;            // 0 or 1
    public int plcBackwardValue;            // 0 or 1
    public Transform cylinderRod;
    public float maxRange;
    public float minRange;
    public float time;
    float currentTime;
    bool isCylinderMoving = false;

    void Update()
    {
        if (plcForwardValue == 1 && isCylinderMoving == false)
            StartCoroutine(CoMoveCylinder(minRange, maxRange, time));
        if (plcBackwardValue == 1 && isCylinderMoving == false)
            StartCoroutine(CoMoveCylinder(maxRange, minRange, time));
    }

    public void OnForwardBtnClkEvent()
    {
        StartCoroutine(CoMoveCylinder(minRange, maxRange, time));
    }

    public void OnBackwardBtnClkEvent()
    {
        StartCoroutine(CoMoveCylinder(maxRange, minRange, time));
    }

    // time���� piston rod�� originPos���� targetPos�� �̵�
    IEnumerator CoMoveCylinder(float minRange, float maxRange, float time)
    {
        isCylinderMoving = true;

        Vector3 originPos = new Vector3(cylinderRod.localPosition.x, minRange, cylinderRod.localPosition.z);
        Vector3 targetPos = new Vector3(cylinderRod.localPosition.x, maxRange, cylinderRod.localPosition.z);

        // time���� piston rod�� originPos���� targetPos�� �̵�
        while (true)
        {
            currentTime += Time.deltaTime;

            if (currentTime > time)
            {
                currentTime = 0;
                break;
            }

            Vector3 newPos = Vector3.Lerp(originPos, targetPos, currentTime / time);
            cylinderRod.localPosition = newPos;

            yield return new WaitForEndOfFrame();
        }

        isCylinderMoving = false;
    }
}