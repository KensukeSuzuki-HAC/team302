using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //�S�[���t���O
    [SerializeField]
    public bool isGoal_ = false;
    public bool IsGoal { get { return isGoal_; } }

    void Start()
    {
        //�S�[���t���O������������
        isGoal_ = false;
    }

    private void OnTriggerEnter (Collider other)
    {
        //�Փˑ��肪Player�^�O�Ȃ�
        if (other.CompareTag("Player"))
        {
            //�S�[���t���O��true�ɂ���
            isGoal_ = true;
            //�R���\�[���ɁhGoal!!�h�ƕ\������
            Debug.Log("Goal!!");
        }
    }
}
