using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g���g�p���邽�߂ɕK�v

public class PauseUIManager : MonoBehaviour
{
    public Button myButton; // �G�f�B�^����A�T�C������{�^���̎Q��
    public GameObject gameObjectToActivate; // �A�N�e�B�u�ɂ���Q�[���I�u�W�F�N�g�̎Q��

    void Start()
    {
        // �{�^����onClick�C�x���g�Ƀ��X�i�[��ǉ�
        myButton.onClick.AddListener(ActivateObject);
    }

    // �Q�[���I�u�W�F�N�g���A�N�e�B�u�ɂ��郁�\�b�h
    void ActivateObject()
    {
        gameObjectToActivate.SetActive(true); // �Q�[���I�u�W�F�N�g���A�N�e�B�u�ɂ���
    }

    void OnDestroy()
    {
        // �I�u�W�F�N�g���j�����ꂽ���Ƀ��X�i�[���폜����i�d�v�j
        myButton.onClick.RemoveListener(ActivateObject);
    }
}
