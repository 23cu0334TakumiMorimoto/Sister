using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainAttack : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    Vector3 worldAngle;//�p�x��������
    public SpriteRenderer spriteRenderer;
    private float currentTime;
    [SerializeField] GameObject punch;
    [SerializeField] Sprite imageIdle;
    [SerializeField] Sprite imagePunch;

    void Start()
    {
        spriteRenderer.sprite = imageIdle;//�ҋ@��Ԃ̉摜
        punch.GetComponent<BoxCollider2D>().enabled = false;//Punch�̓����蔻����Ȃ���
    }

    void Update()
    {

        //if (currentTime > statusdata.SPAN)//2�b���ƂɎ��s�����
        //{
        //    spriteRenderer.sprite = imagePunch;//Player�̉摜���U���p�̉摜�ɐ؂�ւ���
        //    punch.GetComponent<BoxCollider2D>().enabled = true;//�����蔻�������
        //    StartCoroutine("Punchswitch");//�U�������������邽�߂̃R���[�`�����N������
        //    currentTime = 0f;
        //}

    }

    IEnumerator Punchswitch()
    {
        yield return new WaitForSeconds(5);//5�b��ɉ���2�s�����s����
        spriteRenderer.sprite = imageIdle;//�ҋ@��Ԃ̉摜�ɐ؂�ւ���
        punch.GetComponent<BoxCollider2D>().enabled = false;//�����蔻����Ȃ���
    }
}
