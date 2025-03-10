using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 主選單
/// </summary>
public class Mainscense : MonoBehaviour
{
    [Header("音效")]
    [SerializeField]
    private AudioClip soundClick;
    private AudioSource aud;

    /// <summary>
    /// 顯示按鈕控制變數
    /// </summary>
    private bool StartNewGameButton = true;     // 開始新遊戲
    private bool CoutinueGameButton = true;     // 繼續遊戲
    private bool EndGameButton = true;          // 離開遊戲

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 使用 GUI 顯示訊息
    /// </summary>
    protected void OnGUI()
    {
        // 開始新遊戲
        if (StartNewGameButton) 
        {
            if (GUI.Button(new Rect(130, 80, 100, 30), "開始新遊戲"))
            {
                // 當玩家點擊開始新遊戲按鈕時，刪除存檔並切換場景至遊戲場景
                PlayerPrefs.DeleteAll(); 
                StartGame();
            }
        }

       // 繼續遊戲
       if (CoutinueGameButton)
       {
            if (GUI.Button(new Rect(130, 130, 100, 30), "繼續遊戲"))
            {
                //aud.PlayOneShot(soundClick);
                StartGame();
            }
       }

       // 離開遊戲
       if (EndGameButton)
       {
            if (GUI.Button(new Rect(130, 180, 100, 30), "離開遊戲"))
           {
                // 當玩家點擊結束遊戲按鈕時，結束遊戲
                Application.Quit();
                aud.PlayOneShot(soundClick);
            }
       }
    }

    /// <summary>
    /// 開始遊戲的方法
    /// </summary>
    private void StartGame()
    {
        // 切換到遊戲場景
        SceneManager.LoadScene("遊戲");
    }
}


