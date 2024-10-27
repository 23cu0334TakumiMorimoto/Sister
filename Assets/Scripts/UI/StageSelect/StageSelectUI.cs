using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectUI : Selectable, IPointerClickHandler
{
    private StageSelectUI[] _stage;       //�X�e�[�W�z��ϐ�
    private enum _select
    {
        Stage1,
        Stage2,
        Stage3,
        None
    }
    [SerializeField] _select StageSelect;�@�@�@�@//�v���_�E����

    [SerializeField]
    [Header("�����I����Ԃɂ��邩")]
    private bool Init;

    // ���݂̃Z���N�g���
    private bool IsSelected;
    private bool OnClicked;

    // Start is called before the first frame update
    private void Start()
    {
        InitSelect();
    }

    // Update is called once per frame
    private void Update()
    {
        // Enter�L�[�������ꂽ�珈��
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            //Debug.Log("�����ꂽ");
            TransitionStage();
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        // Debug.Log($"{gameObject.name}���I�����ꂽ");

        // transform�̃A�j���[�V����
        transform.localScale = Vector3.one * 1.1f;

        // �t���O��L����
        IsSelected = true;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        //base.OnDeselect(eventData);
        // Debug.Log($"{gameObject.name}�̑I�����O�ꂽ");

        // transform�̃A�j���[�V����
        transform.localScale = Vector3.one;

        // �t���O�𖳌���
        IsSelected = false;
        OnClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�����ꂽ");

        if (OnClicked == true)
        {
            // �N���b�N���ꂽ���ɍs����������
            TransitionStage();
        }

        // �t���O��L����
        OnClicked = true;
    }

    private void TransitionStage()
    {
        if (IsSelected == true)
        {
            if(StageSelect == _select.Stage1)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if (StageSelect == _select.Stage2)
            {
                SceneManager.LoadScene("Stage2");
            }
            else if (StageSelect == _select.Stage3)
            {
                SceneManager.LoadScene("Stage3");
            }
            else if (StageSelect == _select.None)
            {

            }
        }
    }

    public void InitSelect()
    {
        if (Init == true)
        {
            // �I����Ԃɂ���
            EventSystem.current.SetSelectedGameObject(gameObject);
            // �t���O��L����
            IsSelected = true;
        }
    }
}
