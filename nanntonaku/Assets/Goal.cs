using UnityEngine;

public class Goal : MonoBehaviour
{
    // ゴールフラグ
    [SerializeField]
    public bool isGoal_ = false;
    public bool IsGoal { get { return isGoal_; } }

    void Start()
    {
        // ゴールフラグを初期化する
        isGoal_ = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 衝突相手がPlayerタグなら
        if (other.CompareTag("Player"))
        {
            // ゴールフラグをtrueにする
            isGoal_ = true;
            // コンソールに”Goal!!”と表示する
            Debug.Log("Goal!!");

            // GameManagerを取得してスコア加算
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ReachGoal(); // スコア更新処理
            }
        }
    }
}
