using UnityEngine;
using UnityEngine.UI;

public class Manager_Score : MonoBehaviour
{
    // public
    public int iEndScore = 0;

    // private
    private GameObject scGameManager;
    private GameObject gEndScore;

    // 싱글톤 구현
    private static Manager_Score _scScoreManager;

    public static Manager_Score scScoreManager
    {
        get
        {
            if (_scScoreManager == null)
            {
                return null;
            }
            return _scScoreManager;
        }
    }

    private void EndScore()
    {
        if (scGameManager != null)
        {
            iEndScore = scGameManager.GetComponent<Manager_Game>().iScore;
        }
    }

    private void FindEndScoreText()
    {
        gEndScore = GameObject.FindWithTag("EndScore");
        if (gEndScore != null)
        {
            Debug.Log("Test");
            Text tEndScore = gEndScore.GetComponent<Text>();
            tEndScore.text = "Total Score : " + iEndScore;
        }
    }

    void Awake()
    {
        // 싱글톤 구현
        if (null == _scScoreManager)
        {
            _scScoreManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        scGameManager = GameObject.FindWithTag("GameManager");      // 게임 매니저 찾기
    }

    void Update()
    {
        EndScore();
        FindEndScoreText();
    }
}
