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
        //�X�R�A��ScoreScript�ɒǉ�
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        //�Q�[���I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
