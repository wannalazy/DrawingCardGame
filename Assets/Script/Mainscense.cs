using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 主選單
/// </summary>
public class Mainscense : MonoBehaviour
{
    /// <summary>
    /// 顯示按鈕控制變數
    /// </summary>
    private bool StartNewGameButton = true;     // 開始新遊戲
    private bool CoutinueGameButton = true;     // 繼續遊戲
    private bool EndGameButton = true;          // 離開遊戲

    /// <summary>
    /// 使用 GUI 顯示訊息
    /// </summary>
    protected void OnGUI()
    {
        // 開始新遊戲
        if (StartNewGameButton) 
        {
            if (GUI.Button(new Rect(590, 260, 100, 30), "New Game"))
            {
                // 當玩家點擊開始新遊戲按鈕時，刪除存檔並切換場景至遊戲場景
                PlayerPrefs.DeleteAll(); 
                StartGame();
            }
        }

       // 繼續遊戲
       if (CoutinueGameButton)
       {
            if (GUI.Button(new Rect(590, 310, 100, 30), "continue"))
            {
                //aud.PlayOneShot(soundClick);
                StartGame();
            }
       }

       // 離開遊戲
       if (EndGameButton)
       {
            if (GUI.Button(new Rect(590, 360, 100, 30), "leave"))
           {
                // 當玩家點擊結束遊戲按鈕時，結束遊戲
                Application.Quit();
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


