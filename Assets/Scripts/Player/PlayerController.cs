using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : CharacterBase
{
    private BoxCollider2D _boxCollider2D;
    private PlayerActionStateMachine _actionStateMachine;

    private SpriteRenderer _playerSpriteRenderer;

    private Action onResetCallback = null;
    public int MoveDirection { get; private set; }


    private void Awake()
    {
        // �ϐ��̏������E�l�̎擾
       
    }
    private void Start()
    {
        _actionStateMachine = gameObject.GetOrAddComponent<PlayerActionStateMachine>();
    }

    private void Update()
    {
        
    }

}
