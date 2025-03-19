using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace WRX
{ 
    /// <summary>
    /// 抽卡系統
    /// </summary>
    public class DrawingCardGame : MonoBehaviour
    {
        private GUIStyle labelStyle;
        private GUIStyle labelStyle1;
        private GUIStyle labelStyle2;

        /// <summary>
        /// 顯示訊息的文字
        /// </summary>
        private string message1 = "<color=#FFA500>              目標\nEX (0.00001%的機率) !!!</color>";
        private string message = " ";


        /// <summary>
        /// 遊戲按鈕的控制變數 : 抽卡、存檔並離開遊戲
        /// </summary>
        private bool GetCardButton = true;
        private bool SaveAndLeaveGameButton = true;
        private bool EndGameButton = false;



        /// <summary>
        /// 使用 GUI 顯示訊息
        /// </summary>
        protected void OnGUI()
        {
            // 顯示抽卡結果訊息
            GUI.Label(new Rect(400, 100, 400, 500), message1, labelStyle1);
            GUI.Label(new Rect(520, 300, 400, 500), message, labelStyle2);

            // 顯示抽卡統計資訊
            GUI.Label(new Rect(750, 260, 400, 20), $"<color=#FFFFFF>總抽卡次數: {totalDraws} 次</color>", labelStyle);
            GUI.Label(new Rect(750, 310, 400, 20), $"<color=#FFA500>EX卡片(0.001%的機率): {EXCardCount} 次</color>", labelStyle);
            GUI.Label(new Rect(750, 360, 400, 20), $"<color=#800080>S卡片 (10%的機率): {SCardCount} 次</color>", labelStyle);
            GUI.Label(new Rect(750, 410, 400, 20), $"<color=#0000FF>R卡片 (20%的機率): {RCardCount} 次</color>", labelStyle);
            GUI.Label(new Rect(750, 460, 400, 20), $"<color=#00FF00>F卡片 (40%的機率): {FCardCount} 次</color>", labelStyle);
            GUI.Label(new Rect(750, 510, 400, 20), $"<color=#808080>N卡片 (45%的機率): {NCardCount} 次</color>", labelStyle);


            // "抽卡" 按鈕
            if (GetCardButton)
            {
                if (GUI.Button(new Rect(500, 440, 100, 50), "抽卡"))
                {
                    // 點擊後抽卡
                    GetCard();
                }
            }

            // "存檔並離開遊戲" 按鈕
            if (SaveAndLeaveGameButton)
            {
                if (GUI.Button(new Rect(470, 510, 150, 50), "存檔並回到主選單"))
                {
                    SaveGameProgress();    // 存檔
                    SceneManager.LoadScene("主選單");  // 回到主選單
                }
            }
            // 離開遊戲
            if (EndGameButton)
            {
                if (GUI.Button(new Rect(500, 440, 100, 50), "離開遊戲"))
                {
                    // 當玩家點擊結束遊戲按鈕時，結束遊戲
                    Application.Quit();
                }
            }
    }


        /// <summary>
        /// 載入儲存的遊戲進度
        /// </summary>
        private void Start()
        {
            LoadGameProgress();

            labelStyle = new GUIStyle();
            labelStyle1 = new GUIStyle();
            labelStyle2 = new GUIStyle();

            labelStyle.fontSize = 30;
            labelStyle1.fontSize = 50;
            labelStyle2.fontSize = 100;
        }


        /// <summary>
        /// 儲存遊戲進度
        /// </summary>
        private void LoadGameProgress()
        {
            if (PlayerPrefs.HasKey("TotalDraws"))
            {
                totalDraws = PlayerPrefs.GetInt("TotalDraws");
                EXCardCount = PlayerPrefs.GetInt("EXCardCount");
                SCardCount = PlayerPrefs.GetInt("SCardCount");
                RCardCount = PlayerPrefs.GetInt("RCardCount");
                FCardCount = PlayerPrefs.GetInt("FCardCount");
                NCardCount = PlayerPrefs.GetInt("NCardCount");
            }
        }


        /// <summary>
        /// 用來記錄總抽卡次數的變數
        /// </summary>
        private int totalDraws = 0;


        /// <summary>
        /// 用來記錄每種卡片的數量
        /// </summary>
        private int EXCardCount = 0;
        private int SCardCount = 0;
        private int RCardCount = 0;
        private int FCardCount = 0;
        private int NCardCount = 0;


        /// <summary>
        /// 隨機生成數字範圍抽卡方法
        /// </summary>
        private void GetCard()
        {
            int randomNumber = Random.Range(1, 200002);
            Range(randomNumber);
        }

        /// <summary>
        /// 實作卡片方法
        /// </summary>
        private void Range(int range)
        {
            // 每次抽卡，總次數加 1
            totalDraws++;


            // 根據隨機數字的範圍，決定抽到的卡片種類
            if (range >= 200000)
            {
                EXCardCount++;
                message = "<color=#FFA500>EX\n恭喜通關遊戲!!!<color>";
                GetCardButton = false;
                EndGameButton = true;
            }

            else if (range >= 190000 && range < 200000)
            {
                SCardCount++;
                message = "<color=#800080>S</color>";
            }

            else if (range >= 170000 && range < 190000)
            {
                RCardCount++;
                message = "<color=#0000FF>R</color>";
            }

            else if (range >= 90000 && range < 170000)
            {
                FCardCount++;
                message = "<color=#00FF00>F<color>";
            }
            else if (range >= 1 && range < 90000)
            {
                NCardCount++;
                message = "<color=#808080>N<color>";
            }
        }


        /// <summary>
        /// 資料儲存方法
        /// </summary>
        private void SaveGameProgress()
        {
            PlayerPrefs.SetInt("TotalDraws", totalDraws);
            PlayerPrefs.SetInt("EXCardCount", EXCardCount);
            PlayerPrefs.SetInt("SCardCount", SCardCount);
            PlayerPrefs.SetInt("RCardCount", RCardCount);
            PlayerPrefs.SetInt("FCardCount", FCardCount);
            PlayerPrefs.SetInt("NCardCount", NCardCount);
            PlayerPrefs.Save();  // 確保資料被儲存
        }
    }
}


