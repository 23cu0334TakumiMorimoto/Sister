using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sister
{
    namespace StateMachine
    {
        // ---------------------------------------
        // ステートマシン(MonoBehaviour依存)
        // EState -> 列挙型(enum)
        // ---------------------------------------
        public class StateMachine<EState> : MonoBehaviour where EState : System.Enum
        {
            // ステートを入れるDictionary(Key:EState / Value:BaseState<EState>)
            protected Dictionary<EState, BaseState<EState>> _states
                = new Dictionary<EState, BaseState<EState>>();

            // ステート切り替える命令を入れるキュー
            private Queue<EState> _queuedStates
                = new Queue<EState>();

            // 現在ステート
            protected BaseState<EState> _currentState;

            // ステートを切り替えていることを表すフラグ
            protected bool _isTransitioningState = false;

            private void Start()
            {
                // デフォルトステートに入る
                _currentState.EnterState();
            }

            private void Update()
            {

                // ステート更新
                _currentState.UpdateState();

                // 次のステートが入っていたら状態を切り替える
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
            /// ステートを切り替える
            /// </summary>
            /// <param name="nextState">次のステート</param>
            private void TransitionToState(EState nextState)
            {
                // 次のステートと現在のステートが同じだったら終了
                if (_currentState.StateKey.Equals(nextState))   // nextState == _currentState
                    return;

                // ステートが存在しないと終了
                if (!_states.ContainsKey(nextState))
                {
                    Debug.LogWarning(nextState.ToString() + " is not exist");
                    return;
                }

                // ステートを切り替える
                {
                    _isTransitioningState = true;
                    _currentState.ExitState();
                    _currentState = _states[nextState];
                    _currentState.EnterState();
                    _isTransitioningState = false;

                    // フレーム毎にステートの切り替え請求を一回しか受け付けない
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
            /// 次のステートに切り替える
            /// </summary>
            /// <param name="nextState"></param>
            public void SwitchNextState(EState nextState)
            {
                _queuedStates.Enqueue(nextState);
            }

            /// <summary>
            /// 現在のステートを取得する（プロパティ）
            /// </summary>
            public EState CurrentStateKey => _currentState.StateKey;
        }

    }

}
