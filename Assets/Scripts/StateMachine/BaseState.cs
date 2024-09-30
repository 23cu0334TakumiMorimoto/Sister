using System;
using UnityEngine;

namespace Sister
{
    namespace StateMachine
    {

        // ---------------------------------------
        // ベースステートクラス
        // EState -> 列挙型(enum)
        // ---------------------------------------
        [Serializable]
        public class BaseState<EState> where EState : System.Enum
        {
            // ------------------------------
            // コンストラクタ
            // 作成する時にステートを渡すこと
            // ------------------------------
            public BaseState(EState key)
            {
                StateKey = key;
            }

            /// <summary>
            /// 現在のステート（プロパティ）
            /// </summary>
            public EState StateKey { get; private set; }

            /// <summary>
            /// ステートに入る時に呼び出される関数
            /// </summary>
            public virtual void EnterState() { }

            /// <summary>
            /// ステートを出る時に呼び出される関数
            /// </summary>
            public virtual void ExitState() { }

            /// <summary>
            /// ステートを維持している時に呼び出される関数(MonoBehaviour.Update())
            /// </summary>    
            public virtual void UpdateState() { }

            /// <summary>
            /// ステートを維持している時に呼び出される関数(MonoBehaviour.FixedUpdate())
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
