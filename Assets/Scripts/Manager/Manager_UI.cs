using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_UI : MonoBehaviour
{
    public void TitleScene()
    {
        SceneManager.LoadScene("Scene_Title");
    }

    public void InGameScene()
    {
        SceneManager.LoadScene("Scene_InGame");
    }
}
