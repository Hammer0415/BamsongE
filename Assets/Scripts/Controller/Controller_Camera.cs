using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
    // public
    public Transform tCameraPos_01;         // 카메라 시작 위치
    public Transform tCameraPos_02;         // 카메라 줌 인 위치
    public bool bIsZoom = false;            // 카메라 줌 인 아웃 확인 변수
    public float fZoomCoolTime = 1.0f;      // 카메라 줌 쿨타임

    // private
    private float fCurZoomCoolTime = 0.0f;  // 변경 되는 카메라 줌 쿨타임

    // �� �� üũ �Լ�
    public void ZoomIn()
    {
        fCurZoomCoolTime = fZoomCoolTime;
        bIsZoom = true;
    }

    // �� �� �ƿ� ���� �Լ�
    private void ZoomInOut()
    {
        // �� ��Ÿ�� ����
        if (fCurZoomCoolTime >= 0.0f)
        {
            fCurZoomCoolTime -= 1 * Time.deltaTime;     // 카메라 줌 쿨타임 줄이기
        }

        // �� �ƿ� ����
        if (fCurZoomCoolTime <= 0.0f)
        {
            bIsZoom = false;
        }

        // �� �� �ƿ� ����
        if (bIsZoom == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tCameraPos_01.position, Time.deltaTime * 2.0f);             // 카메라 시작 위치로 이동
            this.transform.localRotation = Quaternion.Slerp(this.transform.rotation, tCameraPos_01.rotation, Time.deltaTime * 2.0f);    // 카메라 시작 회전값으로 변경
        }
        if (bIsZoom == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tCameraPos_02.position, Time.deltaTime * 2.0f);             // 카메라 줌 위치로 이동
            this.transform.localRotation = Quaternion.Slerp(this.transform.rotation, tCameraPos_02.rotation, Time.deltaTime * 2.0f);    // 카메라 줌 회전값으로 설정
        }
    }

    void Start()
    {
        this.gameObject.transform.position = tCameraPos_01.position;        // 카메라 시작 위치 설정
        this.gameObject.transform.rotation = tCameraPos_01.rotation;        // 카메라 시작 회전값 설정
    }

    void Update()
    {
        ZoomInOut();
    }
}
