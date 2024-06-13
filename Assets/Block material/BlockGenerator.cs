using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        //ブロックのポジション
        int px, py;
        px = -7; py = 5;
        //ブロックの配置
        for (int i = 0; i < row; i++)
        {

            for (int j = 0; j < col; j++)
            {
                //ゲームオブジェクトの生成
                GameObject go = Instantiate(blockPrefab);
                go.transform.position = new Vector3(px + (j * (span + BlockScaleX)), py + (i * (span + BlockScaleY)), 0);
            }

        }
    }
}