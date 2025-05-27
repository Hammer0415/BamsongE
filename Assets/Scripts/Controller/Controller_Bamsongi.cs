using UnityEngine;

public class Controller_Bamsongi : MonoBehaviour
{
    // public
    public int iWindForceRange = 4;
    // private
    private GameObject scGameManager;           // 게임 메니저 스크립트
    private GameObject cMainCamera;             // 메인 카메라
    private int iWindForce = 0;                 // 바람 세기

    // 발사 함수
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);                                        // 밤송이 오브젝트에 파워주기
    }

    // 충돌 함수
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Target"))
        {
            GetComponent<Rigidbody>().isKinematic = true;           // 충돌 시 정지

            GetComponent<ParticleSystem>().Play();                  // 파티클 시스템 플레이

            scGameManager.GetComponent<Manager_Game>().UpScore(10); // 점수 올리기

            cMainCamera.GetComponent<Controller_Camera>().ZoomIn(); // 카메라 줌 인
        }
    }

    void Start()
    {
        Application.targetFrameRate = 60;                                           // 게임 프레임 조절

        Destroy(this.gameObject, 1.0f);                                             // 3초 후 밤송이 삭제

        scGameManager = GameObject.FindWithTag("GameManager");                      // 게임 메니저 찾기

        cMainCamera = GameObject.FindWithTag("MainCamera");                         // 메인 카메라 찾기

        iWindForce = Random.Range(-iWindForceRange, iWindForceRange);               // 바람 세기 랜덤 값
        Debug.Log(iWindForce);
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * (iWindForce * 5));     // 바람 적용
    }
}
