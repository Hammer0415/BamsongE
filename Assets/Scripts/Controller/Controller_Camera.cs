using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
    // public
    public Transform tCameraPos_01;         // ���� ī�޶� ��ġ
    public Transform tCameraPos_02;         // �� �� ī�޶� ��ġ
    public bool bIsZoom = false;            // ī�޶� �� �� �ƿ� Ȯ�� ����
    public float fZoomCoolTime = 1.0f;      // ī�޶� �� ��Ÿ��

    // private
    private float fCurZoomCoolTime = 0.0f;  // ����Ǵ� ī�޶� �� ��Ÿ��

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
            fCurZoomCoolTime -= 1 * Time.deltaTime;     // �� ��Ÿ�� ���̱�
        }

        // �� �ƿ� ����
        if (fCurZoomCoolTime <= 0.0f)
        {
            bIsZoom = false;
        }

        // �� �� �ƿ� ����
        if (bIsZoom == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tCameraPos_01.position, Time.deltaTime * 2.0f);             // ���� ī�޶� ��ġ�� �̵�
            this.transform.localRotation = Quaternion.Slerp(this.transform.rotation, tCameraPos_01.rotation, Time.deltaTime * 2.0f);    // ���� ī�޶� ȸ�������� ����
        }
        if (bIsZoom == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, tCameraPos_02.position, Time.deltaTime * 2.0f);             // �� �� ī�޶� ��ġ�� �̵�
            this.transform.localRotation = Quaternion.Slerp(this.transform.rotation, tCameraPos_02.rotation, Time.deltaTime * 2.0f);    // ���� ī�޶� ȸ�������� ����
        }
    }

    void Start()
    {
        this.gameObject.transform.position = tCameraPos_01.position;        // ī�޶� ���� ��ġ ���ϱ�
        this.gameObject.transform.rotation = tCameraPos_01.rotation;        // ī�޶� ���� ȸ���� ���ϱ�
    }

    void Update()
    {
        ZoomInOut();
    }
}
