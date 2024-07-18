using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //唯一のインスタンスとして静的変数を生成
    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //スタートメソッド
    public void StartGame()
    {
        SceneData.score = 0;
        SceneManager.LoadScene("game");
    }
    //エンドメソッド
    public void EndGame(int Blocks)
    {
        //獲得したスコアとリザルト画面への遷移
        SceneData.score = ScoreScript.instance.GetCurrentScore();
        SceneData.totalBlocks = Blocks;
        SceneManager.LoadScene("Result");
    }
    //リスタートメソッド
    public void ReturnToStart()
    {
        ResetGame();
        SceneManager.LoadScene("Start");
    }

    public void ResetGame()
    {
        SceneData.score = 0;
        SceneData.totalBlocks = 0;

        //すべてのブロックを削除
        GameObject[] blocks=GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in blocks)
        {
            Destroy(block);        
        }

        //スコアの初期化
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(-ScoreScript.instance.GetCurrentScore());
        }
    }
}
