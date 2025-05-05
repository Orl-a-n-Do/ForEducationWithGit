using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentJumper : MonoBehaviour
{
   private float _speed;
   private NavMeshAgent _agent;
   private AnimationCurve _yOffsetCurve;
   private MonoBehaviour _couroutineRunner;

   private Coroutine _jumpProcess;

    public AgentJumper(float speed, 
    NavMeshAgent agent, 
    MonoBehaviour couroutineRunner,
    AnimationCurve yOffsetCurve)
    {
        _speed = speed;
        _agent = agent;
        _couroutineRunner = couroutineRunner;
        _yOffsetCurve = yOffsetCurve;
    }


    public bool InProcess => _jumpProcess != null;
    

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if(InProcess)
            return;

        _jumpProcess = _couroutineRunner.StartCoroutine(JumpProcess(offMeshLinkData));
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPosition = offMeshLinkData.startPos;
        Vector3 endPostion = offMeshLinkData.endPos;

        float duration = Vector3.Distance(startPosition, endPostion) / _speed;
        float progress = 0;

        while(progress < duration)
        {
             float yOffset = _yOffsetCurve.Evaluate(progress / duration);
            _agent.transform.position = Vector3.Lerp(startPosition, endPostion, progress /duration) + Vector3.up * yOffset;
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _jumpProcess = null;

    }


}
