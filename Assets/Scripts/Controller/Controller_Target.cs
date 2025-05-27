using UnityEngine;

public class Controller_Target : MonoBehaviour
{
    // public
    public float fMoveSpeed = 3.0f;     // Ÿ�� �̵� �ӵ�

    // private
    private bool bIsRight = false;      // �̵� ���� Ȯ��
    private GameObject cMainCamera;     // ���� ī�޶�

    // �¿� �̵� �Լ�
    private void Movement()
    {
        // ���� �̵� Ȯ��
        if (this.transform.position.x >= 3.0f)
        {
            bIsRight = false;
        }

        // ������ �̵� Ȯ��
        if (this.transform.position.x <= -3.0f)
        {
            bIsRight = true;
        }

        if (cMainCamera.GetComponent<Controller_Camera>().bIsZoom == false)
        {
            if (bIsRight == false)
            {
                this.transform.Translate(Vector3.right * (-Time.deltaTime * fMoveSpeed));       // �������� �̵�
            }
            else
            {
                this.transform.Translate(Vector3.right * (Time.deltaTime * fMoveSpeed));        // ���������� �̵�
            }
        }
    }

    void Start()
    {
        cMainCamera = GameObject.FindWithTag("MainCamera");     // ���� ī�޶� ã��
    }

    void Update()
    {
        Movement();
    }
}
