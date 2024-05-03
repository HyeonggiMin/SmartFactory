using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// �����̳� Ŭ����: ������ ����� Ŭ����
public class DeviceInfo
{
    public string name;             // ����Ǹ���
    public string serialNumber;     // �Ǹ���A
    public int operationTime;       // Play��ư ���� ���� �����ð�
    public int operationCount;      // �Ǹ��� ������ Ƚ��
    public string freewarrenty;     // �ϵ���� ���� �����Ⱓ
    public string paidwarrenty;     // �ϵ���� ���� �����Ⱓ

    public DeviceInfo(string name, string serialNumber, int operationTime, int operationCount, string freewarrenty, string paidwarrenty)
    {
        this.name = name;
        this.serialNumber = serialNumber;
        this.operationTime = operationTime;
        this.operationCount = operationCount;
        this.freewarrenty = freewarrenty;
        this.paidwarrenty = paidwarrenty;
    }

}

public class JSONSeriallization : MonoBehaviour
{
    // Object(Class) -> JSON
    public static JSONSeriallization Instance;
    public List<DeviceInfo> devices = new List<DeviceInfo>();

    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name; 
            this.age = age;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // ��ư�� ������, ��� device�� ������ �����Ѵ�.

    // Start is called before the first frame update
    void Start()
    {
        // ���� �����͸� �����ϴ� ���
        DeviceInfo info = new DeviceInfo("������", "123456", 55555, 5555, "2024.05.30", "2026.06.30");

        string json = JsonUtility.ToJson(info); // ����ȭ(serializtion)
        print(json);

        FileStream fs = new FileStream("Assets/file.json", FileMode.Create); // ������ ����, �ݴ� �⺻���� ����� ����
        StreamWriter sw = new StreamWriter(fs); // ���� ������ ������ ����, ���ڵ� ó��
        sw.Write(json);
        sw.Close();
        fs.Close();

        // �������� �����͸� �����ϴ� ���
        DeviceInfo info1 = new DeviceInfo("������1", "123456", 55555, 5555, "2024.05.30", "2026.06.30");
        DeviceInfo info2 = new DeviceInfo("������2", "123456", 55555, 5555, "2024.05.30", "2026.06.30");
        DeviceInfo info3 = new DeviceInfo("������3", "123456", 55555, 5555, "2024.05.30", "2026.06.30");
        DeviceInfo info4 = new DeviceInfo("������4", "123456", 55555, 5555, "2024.05.30", "2026.06.30");
        DeviceInfo info5 = new DeviceInfo("������5", "123456", 55555, 5555, "2024.05.30", "2026.06.30");
        List<DeviceInfo> devices = new List<DeviceInfo>();
        devices.Add(info1);
        devices.Add(info2);
        devices.Add(info3);
        devices.Add(info4);
        devices.Add(info5);

        string json2 = JsonConvert.SerializeObject(devices);
        print(json2);

        // ���Ϸ� ����
        fs = new FileStream("Assets/file2.json", FileMode.Create); // ������ ����, �ݴ� �⺻���� ����� ����
        sw = new StreamWriter(fs); // ���� ������ ������ ����, ���ڵ� ó��
        sw.Write(json2);
        sw.Close();
        fs.Close();

        // DeviceInfo��� �����̳� Ŭ������ ����� �˰� ���� ��� ���
        List<DeviceInfo> newDevices = new List<DeviceInfo>();
        newDevices = JsonConvert.DeserializeObject<List<DeviceInfo>>(json2); 
        DeviceInfo deviceFound = newDevices.Find(x => x.name == "������3");
        print(deviceFound.freewarrenty);

        // ������ ������ ��Ģ�� ���, JOject, JArray ��� ���

        /*JObject jObj = JObject.Parse(json3);
        string title = (string)jObj["channel"]["title"];
        string description = (string)jObj["channel"]["title"][1]["description"];*/


        /*     Person person = new Person("������",27);

               // ��ü -> JSON
               string json = JsonUtility.ToJson(person);

                print(json);

                Person person2 = JsonUtility.FromJson<Person>(json);
                // ��ü -> JSON
                string json = JsonUtility.ToJson(person);

                print($"(person2.name), {person2.age}");
                // JsonUtility.ToJson(json);
            */
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FileStream fs = new FileStream("Assets/fil.json", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string json = sr.ReadToEnd();
            print(json );
            sr.Close();
            fs.Close();
        }
    }
}
