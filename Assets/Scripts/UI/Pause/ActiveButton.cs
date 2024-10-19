using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActiveButton : MonoBehaviour
{
	//�@�ŏ��Ƀt�H�[�J�X����Q�[���I�u�W�F�N�g
	[SerializeField]
	private GameObject firstSelect;

	public void ActivateOrNotActivate(bool flag)
	{
		for (var i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).GetComponent<Button>().interactable = flag;
		}
		if (flag)
		{
			EventSystem.current.SetSelectedGameObject(firstSelect);
		}
	}
}