using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_UI : MonoBehaviour
{
    // 타이틀 씬 이동
    public void TitleScene()
    {
        SceneManager.LoadScene("Scene_Title");
    }

    // 게임 씬 이동
    public void InGameScene()
    {
        SceneManager.LoadScene("Scene_InGame");
    }
}
