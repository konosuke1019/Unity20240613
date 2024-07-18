using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //クラスの唯一のインスタンスを保持するための静的な変数
    public static ScoreScript instance;
    //スコアの表示するためのTextコンポーネントとトータルスコア
    private TextMeshProUGUI scoretext;//TextMeshProUGUIコンポーネントを保持する形に変更
    private int totalScore = 0;

    //プライベートコンストラクタ
    private void Awake()
    {
        //インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);          //シーンをまたいでもインスタンスを保持
            SceneManager.sceneLoaded += OnSceneLoaded;      //シーンがロードされた時に呼び出される
        }
        //既に存在する場合は新しいインスタンスを破棄
        else
        {
            Destroy(gameObject);
        }
    }
    //反映される為のメソッドを定義
    private void Start()
    {
        //初期表示
        UpdateScoreText();
    }
    //スコアを更新して、Textコンポーネントに反映する
    public void ScoreManager(int score)
    {
        totalScore += score;
        //コンポーネントを表示する
        UpdateScoreText();
    }
    //スコアをTextコンポーネントに表示するメソッド
    private void UpdateScoreText()
    {
        if (scoretext != null)
        {
            scoretext.text = "Score : " + totalScore.ToString();
        }
    }
    //トータルのスコア
    public int GetCurrentScore()
    {
        return totalScore;
    }
    //初期化
    public void Initialize()
    {
        //スコアのタグを取得し、スコアを初期化させる
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoretext = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }
    }
    //シーンが呼び出された時にイベントを登録
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //シーンがロードされたのち再初期化
        StartCoroutine(InitializeAfterFrame());
    }

    private IEnumerator InitializeAfterFrame()
    {
        //フレームが終わるまで待つ
        yield return null;
        Initialize();
    }
    //イベントの解除
    private void OnDestroy()
    {
        //解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
