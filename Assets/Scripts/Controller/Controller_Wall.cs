using UnityEngine;

public class Controller_Wall : MonoBehaviour
{
    // ������Ʈ ������ �Լ�
    private void WallRotation()
    {
        this.transform.Rotate(new Vector3(0, 0, 1) * 180 * Time.deltaTime);     // ������Ʈ ������
    }

    void Update()
    {
        WallRotation();
    }
}
