using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockscript : MonoBehaviour
{
    //�����ƂԂ������Ƃ��r���g�C�����\�b�h
    private void OnCollisionEnter(Collision collision)
    {
        //�Q�[���I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
