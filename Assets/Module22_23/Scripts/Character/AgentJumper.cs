using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AgentJumper
{
    private NavMeshAgent _agent;
    private float _speed;
    private MonoBehaviour _coroutineRunner;
    private AnimationCurve _yOffsetCurve;
    private Coroutine _jumpCoroutine;

    public bool InProcess => _jumpCoroutine != null;

    public AgentJumper(NavMeshAgent agent, float speed, MonoBehaviour coroutineRunner, AnimationCurve yOffsetCurve)
    {
        _agent = agent;
        _speed = speed;
        _coroutineRunner = coroutineRunner;
        _yOffsetCurve = yOffsetCurve;
    }

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if (InProcess)
            return;

        _jumpCoroutine = _coroutineRunner.StartCoroutine(JumpCoroutine(offMeshLinkData));
    }

    private IEnumerator JumpCoroutine(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPos = offMeshLinkData.startPos;
        Vector3 endPos = offMeshLinkData.endPos;
        float duration = Vector3.Distance(startPos, endPos) / _speed;
        float time = 0;

        while (time < duration)
        {
            float progress = time / duration;

            _agent.transform.position = Vector3.Lerp(startPos, endPos, progress) + Vector3.up * _yOffsetCurve.Evaluate(progress);
            time += Time.deltaTime;
            yield return null;
        }
        
        _agent.transform.position = endPos;
        _agent.CompleteOffMeshLink();
        _jumpCoroutine = null;
    }
}
