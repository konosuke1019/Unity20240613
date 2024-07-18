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
    //�N���X�̗B��̃C���X�^���X��ێ����邽�߂̐ÓI�ȕϐ�
    public static ScoreScript instance;
    //�X�R�A�̕\�����邽�߂�Text�R���|�[�l���g�ƃg�[�^���X�R�A
    private TextMeshProUGUI scoretext;//TextMeshProUGUI�R���|�[�l���g��ێ�����`�ɕύX
    private int totalScore = 0;

    //�v���C�x�[�g�R���X�g���N�^
    private void Awake()
    {
        //�C���X�^���X�����݂��Ȃ��ꍇ�͂��̃C���X�^���X��ݒ�
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);          //�V�[�����܂����ł��C���X�^���X��ێ�
            SceneManager.sceneLoaded += OnSceneLoaded;      //�V�[�������[�h���ꂽ���ɌĂяo�����
        }
        //���ɑ��݂���ꍇ�͐V�����C���X�^���X��j��
        else
        {
            Destroy(gameObject);
        }
    }
    //���f�����ׂ̃��\�b�h���`
    private void Start()
    {
        //�����\��
        UpdateScoreText();
    }
    //�X�R�A���X�V���āAText�R���|�[�l���g�ɔ��f����
    public void ScoreManager(int score)
    {
        totalScore += score;
        //�R���|�[�l���g��\������
        UpdateScoreText();
    }
    //�X�R�A��Text�R���|�[�l���g�ɕ\�����郁�\�b�h
    private void UpdateScoreText()
    {
        if (scoretext != null)
        {
            scoretext.text = "Score : " + totalScore.ToString();
        }
    }
    //�g�[�^���̃X�R�A
    public int GetCurrentScore()
    {
        return totalScore;
    }
    //������
    public void Initialize()
    {
        //�X�R�A�̃^�O���擾���A�X�R�A��������������
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoretext = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }
    }
    //�V�[�����Ăяo���ꂽ���ɃC�x���g��o�^
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //�V�[�������[�h���ꂽ�̂��ď�����
        StartCoroutine(InitializeAfterFrame());
    }

    private IEnumerator InitializeAfterFrame()
    {
        //�t���[�����I���܂ő҂�
        yield return null;
        Initialize();
    }
    //�C�x���g�̉���
    private void OnDestroy()
    {
        //����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
