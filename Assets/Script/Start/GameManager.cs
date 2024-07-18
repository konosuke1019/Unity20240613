using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�B��̃C���X�^���X�Ƃ��ĐÓI�ϐ��𐶐�
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
    //�X�^�[�g���\�b�h
    public void StartGame()
    {
        SceneData.score = 0;
        SceneManager.LoadScene("game");
    }
    //�G���h���\�b�h
    public void EndGame(int Blocks)
    {
        //�l�������X�R�A�ƃ��U���g��ʂւ̑J��
        SceneData.score = ScoreScript.instance.GetCurrentScore();
        SceneData.totalBlocks = Blocks;
        SceneManager.LoadScene("Result");
    }
    //���X�^�[�g���\�b�h
    public void ReturnToStart()
    {
        ResetGame();
        SceneManager.LoadScene("Start");
    }

    public void ResetGame()
    {
        SceneData.score = 0;
        SceneData.totalBlocks = 0;

        //���ׂẴu���b�N���폜
        GameObject[] blocks=GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in blocks)
        {
            Destroy(block);        
        }

        //�X�R�A�̏�����
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(-ScoreScript.instance.GetCurrentScore());
        }
    }
}