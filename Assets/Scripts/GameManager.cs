using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{

    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            onScoreChange.Invoke(_score);
        }
    }
    private UnityEvent<int> onScoreChange = new UnityEvent<int>();

    public void SubscribeToScoreChange(UnityAction<int> action)
    {
        onScoreChange.AddListener(action);
    }
    public void UnsubscribeToScoreChange(UnityAction<int> action)
    {
        onScoreChange.RemoveListener(action);
    }

    private int _playerLife = 3;
    public int playerLife
    {
        get { return _playerLife; }
        set
        {
            _playerLife = value;
            onPlayerLifeChange.Invoke(_playerLife);
        }
    }
    private UnityEvent<int> onPlayerLifeChange = new UnityEvent<int>();

    public void SubscribeToPlayerLifeChange(UnityAction<int> action)
    {
        onPlayerLifeChange.AddListener(action);
    }
    public void UnsubscribeToPlayerLifeChange(UnityAction<int> action)
    {
        onPlayerLifeChange.RemoveListener(action);
    }

}
