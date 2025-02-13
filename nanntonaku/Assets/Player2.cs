using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public bool isWallHit_R;                //右壁接触のフラグ
    public bool isWallHit_L;                //左壁接触のフラグ
    public bool isWallHit_U;                //上壁接触のフラグ
    public bool isWallHit_D;                //下壁接触のフラグ
    public bool isWallHit_middleU;          //中層上壁接触のフラグ
    public bool isWallHit_middleD;          //中層下壁接触のフラグ
    public bool isGravity;                  //重力反転のフラグ
    public bool isFalling;                  //落下のフラグ
    public float xSpeed = 3.0f;             //横方向の移動スピード
    public float ySpeed = 60.0f;            //上方向の移動スピード

    // Start is called before the first frame update
    void Start()
    {
        isWallHit_R = false;            //初期化
        isWallHit_L = true;	            //初期化
        isWallHit_U = false;            //初期化
        isWallHit_D = false;             //初期化
        isWallHit_middleU = true;      //初期化
        isWallHit_middleD = false;      //初期化
        isGravity = true;              //初期化
        isFalling = false;              //初期化
    }

    // プレイヤーがゴール状態かどうかを判定するフラグ
    private bool isAtGoal = false;

    void Update()
    {
        if (isAtGoal) // ゴールについている場合は動きを止める
        {
            return;
        }

        if (isWallHit_R == true)//右壁についたとき
        {
            //左移動
            transform.position -= transform.right * xSpeed * Time.deltaTime;
        }
        if (isWallHit_L == true)//左壁についたとき
        {
            //右移動
            transform.position += transform.right * xSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))//スペースキーが押されたとき
        {
            if (isFalling == false)//落下フラグが立ってなければ
            {
                isGravity = true;//重力反転フラグを立てる
            }
        }
        if (isGravity == true)//重力反転フラグが立ったとき
        {
            if (isWallHit_U == true || isWallHit_middleU == true)//上壁についていれば
            {
                //下移動
                transform.position -= transform.forward * ySpeed * Time.deltaTime;

            }

            if (isWallHit_D == true || isWallHit_middleD == true)//下壁についていれば
            {
                //上移動
                transform.position += transform.forward * ySpeed * Time.deltaTime;

            }
        }
        if (isFalling == true)//落下フラグが立ったとき
        {
            if (isGravity == false)//重力反転フラグが立っていなければ
            {
                if (isWallHit_middleU == true)
                {
                    //上移動
                    transform.position += transform.forward * ySpeed * Time.deltaTime;
                }

                if (isWallHit_middleD == true)
                {
                    //下移動
                    transform.position -= transform.forward * ySpeed * Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall_R"))
        {
            isWallHit_R = true;
            isWallHit_L = false;

        }
        if (collision.gameObject.CompareTag("Wall_L"))
        {
            isWallHit_R = false;
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
            isWallHit_D = true;
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

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Wall_middleU") || other.gameObject.CompareTag("Wall_middleD"))
        {
            isFalling = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall_Restart"))//リスタート壁を通り抜けたときに
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//シーンを再読み込み
        }
        else if (other.gameObject.CompareTag("Coin")) // コインに触れた場合
        {
            Destroy(other.gameObject); // コインを消去
        }
        else if (other.gameObject.CompareTag("Goal")) // ゴールに触れた場合
        {
            isAtGoal = true; // ゴールフラグを立てる
        }
    }
}
