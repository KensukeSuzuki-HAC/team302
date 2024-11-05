using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度
    public float floatSpeed = 0.5f;    // 上下移動速度
    public float floatAmount = 0.5f;   // 上下移動の幅

    private Vector3 startPosition;     // 初期位置の保存

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置を保存
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Z軸を中心に回転させる
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Z軸での上下移動
        float newZ = startPosition.z + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = new Vector3(startPosition.x, startPosition.y, newZ);
    }
}
