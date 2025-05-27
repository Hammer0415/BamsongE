using UnityEngine;

public class Controller_Target : MonoBehaviour
{
    // public
    public float fMoveSpeed = 3.0f;     // 타겟 이동 속도

    // private
    private bool bIsRight = false;      // 이동 방향 확인
    private GameObject cMainCamera;     // 메인 카메라

    // 좌우 이동 함수
    private void Movement()
    {
        // 왼쪽 이동 확인
        if (this.transform.position.x >= 3.0f)
        {
            bIsRight = false;
        }

        // 오른쪽 이동 확인
        if (this.transform.position.x <= -3.0f)
        {
            bIsRight = true;
        }

        if (cMainCamera.GetComponent<Controller_Camera>().bIsZoom == false)
        {
            if (bIsRight == false)
            {
                this.transform.Translate(Vector3.right * (-Time.deltaTime * fMoveSpeed));       // 왼쪽으로 이동
            }
            else
            {
                this.transform.Translate(Vector3.right * (Time.deltaTime * fMoveSpeed));        // 오른쪽으로 이동
            }
        }
    }

    void Start()
    {
        cMainCamera = GameObject.FindWithTag("MainCamera");     // 메인 카메라 찾기
    }

    void Update()
    {
        Movement();
    }
}
