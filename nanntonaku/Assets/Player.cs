using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isWallHit_R;                //�E�ǐڐG�̃t���O
    public bool isWallHit_L;                //���ǐڐG�̃t���O
    public bool isWallHit_U;                //��ǐڐG�̃t���O
    public bool isWallHit_D;                //���ǐڐG�̃t���O
    public bool isWallHit_middleU;          //���w��ǐڐG�̃t���O
    public bool isWallHit_middleD;          //���w���ǐڐG�̃t���O
    public bool isGravity;                  //�d�͔��]�̃t���O
    public bool isFalling;                  //�����̃t���O
    public float xSpeed = 3.0f;             //�������̈ړ��X�s�[�h
    public float ySpeed = 60.0f;            //������̈ړ��X�s�[�h
    // Start is called before the first frame update
    void Start()
    {
        isWallHit_R = false;            //������
        isWallHit_L = true;	            //������
        isWallHit_U = false;            //������
        isWallHit_D = true;             //������
        isWallHit_middleU = false;      //������
        isWallHit_middleD = false;      //������
        isGravity = false;              //������
        isFalling = false;              //������
    }

    void Update()
    {
        if (isWallHit_R == true)//�E�ǂɂ����Ƃ�
        {
            //���ړ�
            transform.position -= transform.right * xSpeed * Time.deltaTime;
        }
        if (isWallHit_L == true)//���ǂɂ����Ƃ�
        {
           //�E�ړ�
            transform.position += transform.right * xSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))//�X�y�[�X�L�[�������ꂽ�Ƃ�
        {
            if (isFalling == false)//�����t���O�������ĂȂ����
            {
                isGravity = true;//�d�͔��]�t���O�𗧂Ă�
            }
        }
        if (isGravity == true)//�d�͔��]�t���O���������Ƃ�
        {
            if (isWallHit_U == true|| isWallHit_middleU==true)//��ǂɂ��Ă����
            {
                //���ړ�
                transform.position -= transform.forward * ySpeed * Time.deltaTime;
               
            }

            if (isWallHit_D == true|| isWallHit_middleD==true)//���ǂɂ��Ă����
            {
                //��ړ�
                transform.position += transform.forward * ySpeed * Time.deltaTime;
                
            }
        }
        if(isFalling == true)//�����t���O���������Ƃ�
        {
            if (isGravity == false)//�d�͔��]�t���O�������Ă��Ȃ����
            {
                if (isWallHit_middleU == true)
                {
                    //��ړ�
                    transform.position += transform.forward * ySpeed * Time.deltaTime;
                }

                if (isWallHit_middleD == true)
                {
                    //���ړ�
                    transform.position -= transform.forward * ySpeed * Time.deltaTime;
                }
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
            isWallHit_middleU = false;
            isWallHit_middleD = false;
            isGravity = false;
            isFalling = false;
        }
        if (collision.gameObject.CompareTag("Wall_D"))
        {
            isWallHit_U = false;
            isWallHit_D= true;
            isWallHit_middleU = false;
            isWallHit_middleD = false;
            isGravity = false;
            isFalling = false;
        }
        if (collision.gameObject.CompareTag("Wall_middleU"))
        {
            isWallHit_U = false;
            isWallHit_D = false;
            isWallHit_middleU = true;
            isWallHit_middleD = false;
            isGravity = false;
            isFalling = false;
        }
        if (collision.gameObject.CompareTag("Wall_middleD"))
        {
            isWallHit_U = false;
            isWallHit_D = false;
            isWallHit_middleU = false;
            isWallHit_middleD = true;
            isGravity = false;
            isFalling = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if(other.gameObject.CompareTag("Wall_middleU")|| other.gameObject.CompareTag("Wall_middleD"))
       {
            isFalling = true;
       }
    }
}
