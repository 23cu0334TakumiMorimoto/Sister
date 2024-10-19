using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectUI : Selectable, IPointerClickHandler
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

    // ���݂̃Z���N�g���
    private bool IsSelected;

    private GameObject _gameManager;
    private CallUI _pause;

    // �����ւ��摜
    private Image image;

    protected override void Start()
    {
        //if (InitArrow == true)
        //{
        //    // ���𖳌���
        //    _disableArrow1.SetActive(false);
        //    _disableArrow2.SetActive(false);
        //    _disableArrow3.SetActive(false);
        //    // �I����Ԃɂ���
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //    // �t���O��L����
        //    IsSelected = true;
        //}

        _arrowUI = GameObject.Find("LVArrow");
        //// �F��������
        //GetComponent<Image>().material.color = new Color(255, 255, 255);
        _gameManager = GameObject.Find("GameManager");
        _pause = _gameManager.GetComponent<CallUI>();

        // SpriteRenderer���擾
        image = GetComponent<Image>();
    }

    private void Update()
    {
        // Enter�L�[�������ꂽ�珈��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("�����ꂽ");
            SkillProcess();
        }
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
        transform.localScale = Vector3.one * 1.3f;
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
        transform.localScale = Vector3.one;

        // �t���O�𖳌���
        IsSelected = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�����ꂽ");

        if (IsSelected == true)
        {
            // �N���b�N���ꂽ���ɍs����������
            SkillProcess();
        }

        // �t���O��L����
        IsSelected = true;
    }

    void SkillProcess()
    {
        Debug.Log("�X�L������");
        
        //// �����I����ԂȂ�
        //if (InitArrow == true)
        //{
        //    // �I����Ԃɂ���
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //}

        // �E�B���h�E�����
        _pause.PressLVUP();
    }

    // �O������̂݃A�N�Z�X
    // ���̏�����
    public void InitSelect()
    {
        if (InitArrow == true)
        {
            // ���𖳌���
            _disableArrow1.SetActive(false);
            _disableArrow2.SetActive(false);
            _disableArrow3.SetActive(false);
            // �I����Ԃɂ���
            EventSystem.current.SetSelectedGameObject(gameObject);
            // �t���O��L����
            IsSelected = true;
        }
    }

    // �\�͂𔽉f����
    public void ReceiveSkillData(int SkillNum, Sprite SkillSprite)
    {
        Debug.Log(SkillNum);
        image.sprite = SkillSprite;
    }
}
