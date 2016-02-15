using UnityEngine;
using System.Collections;

public class GameState
{
    public virtual string Name { get { return string.Empty; } }

    private GameLogic _gameLogic  = null;
    protected GameLogic GameLogic { get { return _gameLogic; } }

    public GameState( )
    {
        if ( Main.Instance.GameLogic != null )
        {
            _gameLogic = Main.Instance.GameLogic;
        }

    }

    public virtual void Enter()
    {
        _gameLogic = Main.Instance.GameLogic;
    }

    public virtual void Exit()
    {
        _gameLogic = null;
    }

    public virtual void Update()
    {

    }

    public void Load( GameLogic gameLogic )
    {
        
    }
}
