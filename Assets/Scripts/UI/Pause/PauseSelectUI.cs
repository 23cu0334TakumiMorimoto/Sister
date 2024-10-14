using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseSelectUI : Selectable, IPointerClickHandler
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

    // ���݂̃Z���N�g���
    private bool IsSelected;

    private GameObject _gameManager;
    private CallUI _pause;

    [SerializeField]
    [Header("UI�̖���")]
    private UIList _UI;  //�񋓌^�̒l���i�[����ϐ�

    public enum UIList
    {
        Retry, Back
    }

    protected override void Start()
    {
        //if (InitArrow == true)
        //{
        //    // ���𖳌���
        //    _disableArrow1.SetActive(false);
        //    // �I����Ԃɂ���
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //    // �t���O��L����
        //    IsSelected = true;
        //}

        _arrowUI = GameObject.Find("PauseArrow");
        _gameManager = GameObject.Find("GameManager");
        _pause = _gameManager.GetComponent<CallUI>();
    }

    private void Update()
    {
        // Enter�L�[�������ꂽ�珈��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("�����ꂽ");
            PauseProcess();
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
            PauseProcess();
        }

        // �t���O��L����
        IsSelected = true;
    }

    void PauseProcess()
    {
        if(_UI == UIList.Retry)
        {
            Debug.Log("���g���C����");
            // �V�[���������[�h
            _pause.PressPause();
            SceneManager.LoadScene("TestMainGame");
        }
        else if (_UI == UIList.Back)
        {
            Debug.Log("�o�b�N����");
            // �E�B���h�E�����
            _pause.PressPause();
        }

        //// �����I����ԂȂ�
        //if (InitArrow == true)
        //{
        //    // �I����Ԃɂ���
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //}
    }

    // �O������̂݃A�N�Z�X
    public void InitSelect()
    {
        if (InitArrow == true)
        {
            // ���𖳌���
            _disableArrow1.SetActive(false);
            // �I����Ԃɂ���
            EventSystem.current.SetSelectedGameObject(gameObject);
            // �t���O��L����
            IsSelected = true;
        }
    }
}
