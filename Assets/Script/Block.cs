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
        //�X�R�A��ScoreScript�ɒǉ�
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("ScoreScript instance is not set.");
        }
        //GetComponent<AudioSource>.Play();
        //�g�[�^���u���b�N�̍폜���\�b�h
        generator.BlockDestroyed();
        //�Q�[���I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
