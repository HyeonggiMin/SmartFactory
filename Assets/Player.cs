using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public GameObject sphere;
    void Start()
    {
      
    }



    void Update()
    {
        // 방향키 좌우 or A,D 키입력 값을 반환
        float h = Input.GetAxis("Horizontal"); // -1 ~ 1
        float v = Input.GetAxis("Vertical");
        print(h);

        // transform.Translate(Vector3.right * Time.deltaTime  * speed);
        //Vector3 direction = (Vector3.right * h) + (Vector3.forward * v); // (1, 0, 0) * -1 = (-1, 0, 0)
                            // x(좌우), y(앞뒤), z(위아래)
        Vector3 direction = new Vector3(h, 0, v);
        
        transform.position += (direction * Time.deltaTime * speed);

        print("Space Button Pressed!");
        GameObject obj = Instantiate(sphere);
        // 위에랑 같은 표현 List<string> strings =  new List<string>();

        float randX = UnityEngine.Random.Range(0.0f, 1.0f);
        float randY = UnityEngine.Random.Range(0.0f, 1.0f);
        float randZ = UnityEngine.Random.Range(0.0f, 1.0f);
        obj.transform.position = new Vector3(randX, randY, randZ);

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
