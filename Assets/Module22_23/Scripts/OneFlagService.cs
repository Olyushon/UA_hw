using UnityEngine;

public class OneFlagService : MonoBehaviour
{
    [SerializeField] private GameObject _flagPrefab;
    [SerializeField] private AgentCharacter _agentCharacter;
    private GameObject _currentFlag;

    public GameObject CurrentFlag => _currentFlag;

    private void Update()
    {
        if (_currentFlag == null && _agentCharacter.HasPath)
        {
            PutFlag(_agentCharacter.Destination);
        }
        else if (_currentFlag != null && _agentCharacter.IsDestinationReached)
        {
            RemoveFlag();
        }
    }

    public void PutFlag(Vector3 position)
    {
        _currentFlag = Instantiate(_flagPrefab, position, Quaternion.identity);
    }

    public void RemoveFlag()
    {
        Destroy(_currentFlag);
        _currentFlag = null;
    }
}
