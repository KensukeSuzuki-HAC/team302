using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x
    public float floatSpeed = 0.5f;    // �㉺�ړ����x
    public float floatAmount = 0.5f;   // �㉺�ړ��̕�

    private Vector3 startPosition;     // �����ʒu�̕ۑ�

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Z���𒆐S�ɉ�]������
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Z���ł̏㉺�ړ�
        float newZ = startPosition.z + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = new Vector3(startPosition.x, startPosition.y, newZ);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[�ƐڐG�����ꍇ
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.CollectCoin(); // �X�R�A���Z
            }
            Destroy(gameObject); // �R�C�����폜
        }
    }
}
