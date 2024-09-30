using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sister
{
    namespace StateMachine
    {
        // ---------------------------------------
        // �X�e�[�g�}�V��(MonoBehaviour�ˑ�)
        // EState -> �񋓌^(enum)
        // ---------------------------------------
        public class StateMachine<EState> : MonoBehaviour where EState : System.Enum
        {
            // �X�e�[�g������Dictionary(Key:EState / Value:BaseState<EState>)
            protected Dictionary<EState, BaseState<EState>> _states
                = new Dictionary<EState, BaseState<EState>>();

            // �X�e�[�g�؂�ւ��閽�߂�����L���[
            private Queue<EState> _queuedStates
                = new Queue<EState>();

            // ���݃X�e�[�g
            protected BaseState<EState> _currentState;

            // �X�e�[�g��؂�ւ��Ă��邱�Ƃ�\���t���O
            protected bool _isTransitioningState = false;

            private void Start()
            {
                // �f�t�H���g�X�e�[�g�ɓ���
                _currentState.EnterState();
            }

            private void Update()
            {

                // �X�e�[�g�X�V
                _currentState.UpdateState();

                // ���̃X�e�[�g�������Ă������Ԃ�؂�ւ���
                if (_queuedStates.Count != 0)
                {
                    TransitionToState(_queuedStates.Dequeue());
                }
            }

            private void FixedUpdate()
            {
                _currentState.FixedUpdateState();
            }

            /// <summary>
            /// �X�e�[�g��؂�ւ���
            /// </summary>
            /// <param name="nextState">���̃X�e�[�g</param>
            private void TransitionToState(EState nextState)
            {
                // ���̃X�e�[�g�ƌ��݂̃X�e�[�g��������������I��
                if (_currentState.StateKey.Equals(nextState))   // nextState == _currentState
                    return;

                // �X�e�[�g�����݂��Ȃ��ƏI��
                if (!_states.ContainsKey(nextState))
                {
                    Debug.LogWarning(nextState.ToString() + " is not exist");
                    return;
                }

                // �X�e�[�g��؂�ւ���
                {
                    _isTransitioningState = true;
                    _currentState.ExitState();
                    _currentState = _states[nextState];
                    _currentState.EnterState();
                    _isTransitioningState = false;

                    // �t���[�����ɃX�e�[�g�̐؂�ւ���������񂵂��󂯕t���Ȃ�
                    _queuedStates.Clear();
                }
            }

            private void OnCollisionEnter2D(Collision2D collision)
            {
                _currentState.OnCollisionEnter(collision);
            }
            private void OnCollisionStay2D(Collision2D collision)
            {
                _currentState.OnCollisionStay(collision);
            }
            private void OnCollisionExit2D(Collision2D collision)
            {
                _currentState.OnCollisionExit(collision);
            }
            private void OnTriggerEnter2D(Collider2D collision)
            {
                _currentState.OnTriggerEnter(collision);
            }
            private void OnTriggerStay2D(Collider2D collision)
            {
                _currentState.OnTriggerStay(collision);
            }
            private void OnTriggerExit2D(Collider2D collision)
            {
                _currentState.OnTriggerExit(collision);
            }

            /// <summary>
            /// ���̃X�e�[�g�ɐ؂�ւ���
            /// </summary>
            /// <param name="nextState"></param>
            public void SwitchNextState(EState nextState)
            {
                _queuedStates.Enqueue(nextState);
            }

            /// <summary>
            /// ���݂̃X�e�[�g���擾����i�v���p�e�B�j
            /// </summary>
            public EState CurrentStateKey => _currentState.StateKey;
        }

    }

}
