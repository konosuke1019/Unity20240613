using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int score = 0;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        //ScoreScript.instance.ScoreManager(score);
        //スコアをScoreScriptに追加
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        //ゲームオブジェクトを削除
        Destroy(gameObject);
    }
}
