using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestSelectUI : Selectable
{
    [SerializeField]
    [Header("�����I����Ԃɂ��邩")]
    private bool InitArrow;

    private GameObject _arrowUI;
    [SerializeField]
    [Header("�L����������")]
    private GameObject _activeArrow;

    [SerializeField]
    [Header("������������")]
    private GameObject _disableArrow1;
    [SerializeField]
    private GameObject _disableArrow2;
    [SerializeField]
    private GameObject _disableArrow3;

    protected override void Start()
    {
        if (InitArrow == true)
        {
            // ���𖳌���
            _disableArrow1.SetActive(false);
            _disableArrow2.SetActive(false);
            _disableArrow3.SetActive(false);
            // �I����Ԃɂ���
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        _arrowUI = GameObject.Find("Arrow");
        //// �F��������
        //GetComponent<Image>().material.color = new Color(255, 255, 255);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}���I�����ꂽ");

        // ����L����
        _activeArrow.SetActive(true);

        //// �F��ύX
        //GetComponent<Image>().material.color = new Color(255, 0, 0);

        // transform�̃A�j���[�V����
        transform.localScale = Vector3.one * 1.3f; // ���[�v�Ŋg��E�k��
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name}�̑I�����O�ꂽ");

        // ���𖳌���
        _activeArrow.SetActive(false);

        //// �F��߂�
        //GetComponent<Image>().material.color = new Color(255, 255, 255);

        // transform�̃A�j���[�V����
        transform.localScale = Vector3.one; // ���[�v�Ŋg��E�k��
    }
}

