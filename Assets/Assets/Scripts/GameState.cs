using UnityEngine;
using System.Collections;

public class GameState
{
    public virtual string Name { get { return string.Empty; } }

    private GameLogic _gameLogic  = null;
    protected GameLogic GameLogic { get { return _gameLogic; } }

    public GameState( GameLogic gameLogic )
    {
        Init( gameLogic );
    }

    // required by serializer
    public GameState()
    { 
    }

    private void Init(GameLogic gameLogic)
    {
        _gameLogic = gameLogic;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }

    public void Load( GameLogic gameLogic )
    {
        Init( gameLogic );
    }
}
