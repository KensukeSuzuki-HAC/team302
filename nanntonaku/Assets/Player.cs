using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isWallHit_R;//�E�ǐڐG�̃t���O
    public bool isWallHit_L;//���ǐڐG�̃t���O
    public bool isWallHit_U;//��ǐڐG�̃t���O
    public bool isWallHit_D;//���ǐڐG�̃t���O
    public bool isGravity;//�d�͔��]�̃t���O
    public float xSpeed = 3.0f;//�������̈ړ��X�s�[�h
    public float ySpeed = 60.0f;//������̈ړ��X�s�[�h
    // Start is called before the first frame update
    void Start()
    {
        isWallHit_R = false;    //������
        isWallHit_L = true;	    //������
        isWallHit_U = false;    //������
        isWallHit_D = true;    //������
        isGravity= false;//������
    }

    // Update is called once per frame
    void Update()
    {
        if (isWallHit_R == true)
        {
            //���ړ�
            transform.position -= transform.right * xSpeed * Time.deltaTime;
        }
        if (isWallHit_L == true)
        {
           //�E�ړ�
            transform.position += transform.right * xSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))//�X�y�[�X�L�[�������ꂽ��
        {
            isGravity = true;
        }
        if (isGravity == true)
        {
            if (isWallHit_U == true)
            {
                //���ړ�
                transform.position -= transform.forward * ySpeed * Time.deltaTime;
               
            }

            if (isWallHit_D == true)
            {
                //��ړ�
                transform.position += transform.forward * ySpeed * Time.deltaTime;
                
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Wall_R"))
        {
            isWallHit_R = true;
            isWallHit_L = false;
        }
        if (collision.gameObject.CompareTag("Wall_L"))
        {
            isWallHit_R =false;
            isWallHit_L = true;
        }
        if (collision.gameObject.CompareTag("Wall_U"))
        {
            isWallHit_U = true;
            isWallHit_D = false;
            isGravity = false;
        }
        if (collision.gameObject.CompareTag("Wall_D"))
        {
            isWallHit_U = false;
            isWallHit_D= true;
            isGravity = false;
        }
    }
}
