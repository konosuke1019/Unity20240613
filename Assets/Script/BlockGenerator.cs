using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockGenerator : MonoBehaviour
{
    //GameObjectの追加
    public GameObject blockPrefab;
    //スパン
    float span = 0.3f;
    int row = 4;
    int col = 7;
    int BlockScaleX = 2;
    int BlockScaleY = 1;
    int totalBlocks = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ブロックのポジション
        int px, py;
        px = -7; py = 5;
        int scoreDefault = 0;
        totalBlocks = row * col;
        //SceneData.totalBlocks= totalBlocks;
        //ブロックの配置
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //ゲームオブジェクトの生成
                GameObject blocks = Instantiate(blockPrefab);
                blocks.transform.position = new Vector3(px + (j * (span + BlockScaleX)), py + (i * (span + BlockScaleY)), 0);
                blocks.tag = "Blocks";
            }
        }
        //スコアの初期化
        ScoreScript.instance.ScoreManager(scoreDefault);
    }

    //ゲームクリア
    public void BlockDestroyed()
    {
        totalBlocks--;
        SceneData.totalBlocks = totalBlocks;
        if (totalBlocks <= 0)
        {
            GameManager.instance.EndGame(totalBlocks);
        }
    }
}
