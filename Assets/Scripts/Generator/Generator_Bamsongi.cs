using UnityEngine;

public class Generator_Bamsongi : MonoBehaviour
{
    // public
    public GameObject gBamsongiPrefab;              // 밤송이 게임 오브젝트
    public Controller_Power scPowerController;      // 파워 컨트롤러 스크립트
    public Transform tBamsongiTransform;            // 밤송이 스폰 위치

    // private
    private GameObject scGameManager;               // 게임 메니저 스크립트
    private GameObject scCameraController;          // 카메라 컨트롤러

    private void CreateBamsongi()
    {
        bool bIsZooming = scCameraController.GetComponent<Controller_Camera>().bIsZoom;         // 카메라 줌 확인
        int iGameCounting = scGameManager.GetComponent<Manager_Game>().iGameCount;              // 남은 횟수 확인

        if (bIsZooming == false && iGameCounting != 0)
        {
            // 마우스를 눌렀을 때
            if (Input.GetMouseButtonDown(0))
            {
                scPowerController.bIsClick = true;          // 클릭 확인 변수 변경
                scPowerController.fPowerValue = 0.0f;       // 클릭시 파워값 0으로 변경
            }

            // 마우스를 땠을 때
            if (Input.GetMouseButtonUp(0))
            {
                GameObject gBamsongi = Instantiate(gBamsongiPrefab);                                            // 밤송이 오브젝트 복사

                gBamsongi.transform.position = tBamsongiTransform.position;                                     // 밤송이 오브젝트 소환 위치 설정

                Ray rScreen = Camera.main.ScreenPointToRay(Input.mousePosition);                                // 스크린속 마우스 포지션 구하기
                Vector3 vWorldDir = rScreen.direction;                                                          // 스크린 좌표를 월드 좌표로 바꾸기

                float fPower = scPowerController.fPowerValue;                                                   // 파워값 가져오기

                gBamsongi.GetComponent<Controller_Bamsongi>().Shoot(vWorldDir.normalized * (200 * fPower));     // 밤송이 발사

                scPowerController.bIsClick = false;                                                             // 클릭 확인 변수 변경

                scGameManager.GetComponent<Manager_Game>().CheckGameCount();                                    // 게임 횟수 줄이기
            }
        }
    }

    void Start()
    {
        scGameManager = GameObject.FindWithTag("GameManager");          // 게임 메니저 찾기
        scCameraController = GameObject.FindWithTag("MainCamera");      // 메인 카메라 찾기
    }

    void Update()
    {
        CreateBamsongi();
    }
}
