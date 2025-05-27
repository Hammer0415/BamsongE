using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
    // public
    public Transform tCameraPos_01;         // 시작 카메라 위치
    public Transform tCameraPos_02;         // 줌 인 카메라 위치
    public bool bIsZoom = false;            // 카메라 줌 인 아웃 확인 변수
    public float fZoomCoolTime = 1.0f;      // 카메라 줌 쿨타임

    // private
    private float fCurZoomCoolTime = 0.0f;  // 변경되는 카메라 줌 쿨타임

    // 줌 인 체크 함수
    public void ZoomIn()
    {
        fCurZoomCoolTime = fZoomCoolTime;
        bIsZoom = true;
    }

    // 줌 인 아웃 구현 함수
    private void ZoomInOut()
    {
        // 줌 쿨타임 구현
        if (fCurZoomCoolTime >= 0.0f)
        {
            fCurZoomCoolTime -= 1 * Time.deltaTime;     // 줌 쿨타임 줄이기
        }

        // 줌 아웃 구현
        if (fCurZoomCoolTime <= 0.0f)
        {
            bIsZoom = false;
        }

        // 줌 인 아웃 구현
        if (bIsZoom == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tCameraPos_01.position, Time.deltaTime * 2.0f);             // 시작 카메라 위치로 이동
            this.transform.localRotation = Quaternion.Slerp(this.transform.rotation, tCameraPos_01.rotation, Time.deltaTime * 2.0f);    // 시작 카메라 회전값으로 변경
        }
        if (bIsZoom == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tCameraPos_02.position, Time.deltaTime * 2.0f);             // 줌 인 카메라 위치로 이동
            this.transform.localRotation = Quaternion.Slerp(this.transform.rotation, tCameraPos_02.rotation, Time.deltaTime * 2.0f);    // 시작 카메라 회전값으로 변경
        }
    }

    void Start()
    {
        this.gameObject.transform.position = tCameraPos_01.position;        // 카메라 시작 위치 정하기
        this.gameObject.transform.rotation = tCameraPos_01.rotation;        // 카메라 시작 회전값 정하기
    }

    void Update()
    {
        ZoomInOut();
    }
}
