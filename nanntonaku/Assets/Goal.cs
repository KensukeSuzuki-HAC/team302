using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //ゴールフラグ
    [SerializeField]
    public bool isGoal_ = false;
    public bool IsGoal { get { return isGoal_; } }

    void Start()
    {
        //ゴールフラグを初期化する
        isGoal_ = false;
    }

    private void OnTriggerEnter (Collider other)
    {
        //衝突相手がPlayerタグなら
        if (other.CompareTag("Player"))
        {
            //ゴールフラグをtrueにする
            isGoal_ = true;
            //コンソールに”Goal!!”と表示する
            Debug.Log("Goal!!");
        }
    }
}
