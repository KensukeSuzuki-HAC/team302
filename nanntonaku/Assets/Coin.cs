using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x
    public float floatSpeed = 0.5f;    // �㉺�ړ����x
    public float floatAmount = 0.5f;   // �㉺�ړ��̕�

    private Vector3 startPosition;     // �����ʒu�̕ۑ�

    // Start is called before the first frame update
    void Start()
    {
        // �����ʒu��ۑ�
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Z���𒆐S�ɉ�]������
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Z���ł̏㉺�ړ�
        float newZ = startPosition.z + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = new Vector3(startPosition.x, startPosition.y, newZ);
    }
}
