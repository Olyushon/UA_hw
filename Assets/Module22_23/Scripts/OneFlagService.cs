using UnityEngine;

public class OneFlagService : MonoBehaviour
{
    [SerializeField] private GameObject _flagPrefab;
    private GameObject _currentFlag;

    public GameObject CurrentFlag => _currentFlag;

    public void PutFlag(Vector3 position)
    {
        if (_currentFlag == null)
        _currentFlag = Instantiate(_flagPrefab, position, Quaternion.identity);
    }

    public void RemoveFlag()
    {
        Destroy(_currentFlag);
        _currentFlag = null;
    }
}
