using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------
// �쐬��:�X�{��
// �w�i�X�N���[��������X�N���v�g
// transform�œ������Ă��܂�
// -----------------------------------------

public class Background : MonoBehaviour
{
    [SerializeField]
    [Header("�X�N���[���X�s�[�h")]
    public float scrollSpeed;

    private Vector3 _cameraRectMin;

    void Start()
    {
        // �J�����͈̔͂��擾
        _cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        // X�������ɃX�N���[��
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);  
        // �J�����̍��[���犮�S�ɏo����A�E�[�ɏu�Ԉړ�
        if (transform.position.x < (_cameraRectMin.x - Camera.main.transform.position.x) * 2)
        {
            transform.position = new Vector2((Camera.main.transform.position.x - _cameraRectMin.x) * 2 + 5, transform.position.y);
        }
    }
}