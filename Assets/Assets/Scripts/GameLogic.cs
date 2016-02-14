using UnityEngine;
using System.Collections;

public class GameLogic : BaseClass
{
    private GameState _currentState = null;
    private Default   _default = null;
    private Increment _increment = null;
    private Decrement _decrement = null;


    private int _counter = 0;

    public GameLogic()
        :base()
    {
        Init();
    }
    private void Init()
    {
        _default   = new Default( this );
        _increment = new Increment( this );
        _decrement = new Decrement( this );

        ChangeState( _default );
    }

    public GameState CurrentState { get { return _currentState; }  }
    public int Counter { get { return _counter; } }

    public void Update()
    {
        if ( _currentState != null )
        {
            _currentState.Update();
        }
    }

    protected override void OnSave( Data data )
    {
        data.GameLogicContainer.Counter = _counter;
        data.GameLogicContainer.CurrentState = _currentState;
    }

    protected override void OnLoad( Data data )
    {
        _counter = data.GameLogicContainer.Counter;
        _currentState = data.GameLogicContainer.CurrentState;
        _currentState.Load( this );
    }

    private void ChangeState( GameState state )
    {
        if ( _currentState != null )
        {
            _currentState.Exit();
        }

        _currentState = state;

        _currentState.Enter();
    }

    public void ChangeToIncrement()
    {
        ChangeState( _increment );
    }

    public void ChangeToDecrement()
    {
        ChangeState( _decrement );
    }

    public void ChangeToDefault()
    {
        ChangeState( _default );
    }

    public void IncrementCounter()
    {
        _counter++;
    }

    public void DecrementCounter()
    {
        _counter--;
    }
}
