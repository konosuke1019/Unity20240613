using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int score = 10;
    BlockGenerator generator;
    private void Start()
    {
        generator=FindObjectOfType<BlockGenerator>();
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        //ScoreScript.instance.ScoreManager(score);
        //スコアをScoreScriptに追加
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("ScoreScript instance is not set.");
        }
        //GetComponent<AudioSource>.Play();
        //トータルブロックの削除メソッド
        generator.BlockDestroyed();
        //ゲームオブジェクトを削除
        Destroy(gameObject);
    }
}
