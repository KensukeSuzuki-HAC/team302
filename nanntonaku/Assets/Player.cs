using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isWallHit_R;//右壁接触のフラグ
    public bool isWallHit_L;//左壁接触のフラグ
    public bool isWallHit_U;//上壁接触のフラグ
    public bool isWallHit_D;//下壁接触のフラグ
    public bool isGravity;//重力反転のフラグ
    public float xSpeed = 3.0f;//横方向の移動スピード
    public float ySpeed = 60.0f;//上方向の移動スピード
    // Start is called before the first frame update
    void Start()
    {
        isWallHit_R = false;    //初期化
        isWallHit_L = true;	    //初期化
        isWallHit_U = false;    //初期化
        isWallHit_D = true;    //初期化
        isGravity= false;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        if (isWallHit_R == true)
        {
            //左移動
            transform.position -= transform.right * xSpeed * Time.deltaTime;
        }
        if (isWallHit_L == true)
        {
           //右移動
            transform.position += transform.right * xSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))//スペースキーが押されたら
        {
            isGravity = true;
        }
        if (isGravity == true)
        {
            if (isWallHit_U == true)
            {
                //下移動
                transform.position -= transform.forward * ySpeed * Time.deltaTime;
               
            }

            if (isWallHit_D == true)
            {
                //上移動
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
