using System;
using UnityEngine;

namespace Sister
{
    namespace StateMachine
    {

        // ---------------------------------------
        // �x�[�X�X�e�[�g�N���X
        // EState -> �񋓌^(enum)
        // ---------------------------------------
        [Serializable]
        public class BaseState<EState> where EState : System.Enum
        {
            // ------------------------------
            // �R���X�g���N�^
            // �쐬���鎞�ɃX�e�[�g��n������
            // ------------------------------
            public BaseState(EState key)
            {
                StateKey = key;
            }

            /// <summary>
            /// ���݂̃X�e�[�g�i�v���p�e�B�j
            /// </summary>
            public EState StateKey { get; private set; }

            /// <summary>
            /// �X�e�[�g�ɓ��鎞�ɌĂяo�����֐�
            /// </summary>
            public virtual void EnterState() { }

            /// <summary>
            /// �X�e�[�g���o�鎞�ɌĂяo�����֐�
            /// </summary>
            public virtual void ExitState() { }

            /// <summary>
            /// �X�e�[�g���ێ����Ă��鎞�ɌĂяo�����֐�(MonoBehaviour.Update())
            /// </summary>    
            public virtual void UpdateState() { }

            /// <summary>
            /// �X�e�[�g���ێ����Ă��鎞�ɌĂяo�����֐�(MonoBehaviour.FixedUpdate())
            /// </summary>    
            public virtual void FixedUpdateState() { }

            public virtual void OnCollisionEnter(Collision2D collision) { }
            public virtual void OnCollisionStay(Collision2D collision) { }
            public virtual void OnCollisionExit(Collision2D collision) { }
            public virtual void OnTriggerEnter(Collider2D collision) { }
            public virtual void OnTriggerStay(Collider2D collision) { }
            public virtual void OnTriggerExit(Collider2D collision) { }

        }

    }
}
