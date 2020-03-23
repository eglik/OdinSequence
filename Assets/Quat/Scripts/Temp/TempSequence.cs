using UnityEngine;
using UnityEngine.UI;

namespace Quat
{
    public class TempSequence : Sequence
    {
        private void Awake()
        {
            // UI Initialize in here
            // UI 초기화는 이곳에서
        }

        public override void BeginSequence()
        {
            // Call when sequence begin
            // Useful to reset UI
            // 시퀀스가 실행될때 실행됨
            // UI를 재설정할때 유용함
        }

        public override void EndSequence()
        {
            // Call when sequence end
            // 시퀀스가 종료될때 실행됨
        }

        protected override void SequenceProcess(float process)
        {
            // This method is running in sequence coroutine (range 0-1)
            // Make some animation worked at process value
            // 이 메소드는 시퀀스 코루틴에서 동작함 (범위 0-1)
            // process 수치에 맞게 동작하는 애니메이션을 만들 수 있음
        }
    }
}