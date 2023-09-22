using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Paused,
    Restarting,
    Playing,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    private GameState _gameState = GameState.Paused;
    public GameState gameState
    {
        get { return _gameState; }
        set
        {
            if (_gameState == GameState.GameOver && value == GameState.Playing)
            {
                score = 0;
                playerLife = 3;
                _gameState = GameState.Restarting;
                onGameStateChange.Invoke(_gameState);
                return;
            }

            _gameState = value;
            if (_gameState == GameState.Playing) Time.timeScale = 1;
            if (_gameState == GameState.Paused || _gameState == GameState.GameOver) Time.timeScale = 0;
            onGameStateChange.Invoke(_gameState);
        }
    }
    private UnityEvent<GameState> onGameStateChange = new UnityEvent<GameState>();

    public void SubscribeToGameStateChange(UnityAction<GameState> action)
    {
        onGameStateChange.AddListener(action);
    }

    public void UnsubscribeToGameStateChange(UnityAction<GameState> action)
    {
        onGameStateChange.RemoveListener(action);
    }

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
            if (_playerLife <= 0) gameState = GameState.GameOver;
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

    private UnityEvent<GameObject, int> onBubbleDestroyed = new UnityEvent<GameObject, int>();

    public void SubscribeToBubbleDestroyed(UnityAction<GameObject, int> action)
    {
        onBubbleDestroyed.AddListener(action);
    }

    public void UnsubscribeToBubbleDestroyed(UnityAction<GameObject, int> action)
    {
        onBubbleDestroyed.RemoveListener(action);
    }

    public void BubbleDestroyed(GameObject bubble, int score)
    {
        onBubbleDestroyed.Invoke(bubble, score);
    }

}
