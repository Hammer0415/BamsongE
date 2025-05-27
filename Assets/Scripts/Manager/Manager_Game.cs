using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoBehaviour
{
    // public
    public int iScore = 0;                                          // 점수
    public int iGameCount = 10;                                     // 남은 게임 횟수
    public Text tScore;                                             // 스코어 표시 UI
    public Text tGameCount;                                         // 남은 게임 횟수 표시 UI

    // private
    private GameObject scCameraController;                          // 카메라 컨트롤러
    private float fEndTimer = 0.0f;                                 // 게임 끝내는 타이머

    // 점수 올리기 함수
    public void UpScore(int iUpScore)
    {
        iScore += iUpScore;         // 점수 올리기
    }

    // 남은 횟수 줄이기 함수
    public void CheckGameCount()
    {
        iGameCount -= 1;            // 남은 게임 횟수 줄이기
    }

    // UI 세팅 함수
    private void UISetting()
    {
        tScore.text = "Score : " + iScore.ToString();
        tGameCount.text = "남은 횟수 : " + iGameCount.ToString();
    }

    // 횟수 전부 사용 시 씬 이동
    private void EndScene()
    {
        if (iGameCount == 0 && scCameraController.GetComponent<Controller_Camera>().bIsZoom == false)
        {
            fEndTimer += 1 * Time.deltaTime; ;              // 게임 끝내는 타이머 증가

            if (fEndTimer > 3.0f)
            {
                SceneManager.LoadScene("Scene_End");        // 씬 불러오기
            }
        }
    }

    void Start()
    {
        scCameraController = GameObject.FindWithTag("MainCamera");      // 메인 카메라 찾기
    }

    void Update()
    {
        UISetting();
        EndScene();
    }
}
