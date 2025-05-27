using UnityEngine;

public class Controller_Wall : MonoBehaviour
{
    // 방어벽 돌리는 함수
    private void WallRotation()
    {
        this.transform.Rotate(new Vector3(0, 0, 1) * 180 * Time.deltaTime);     // 방어벽 돌리기
    }

    void Update()
    {
        WallRotation();
    }
}
