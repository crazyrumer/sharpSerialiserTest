using UnityEngine;
using System.Collections;

public class GameLogic : BaseClass
{
    private GameLogicSerialisable _glSerialisable = null;
    private Default   _default = null;
    private Increment _increment = null;
    private Decrement _decrement = null;

    public int Counter 
    { 
        get { return _glSerialisable.Counter; } 
        private set { _glSerialisable.Counter = value; } 
    }
    public GameState CurrentState 
    { 
        get { return _glSerialisable.CurrentState; }
        private set { _glSerialisable.CurrentState = value; }
    }

    public GameLogic()
        :base()
    {
        Init();
    }
    private void Init()
    {
        _glSerialisable = new GameLogicSerialisable();

        Counter = 0;

        _default   = new Default( );
        _increment = new Increment( );
        _decrement = new Decrement( );
    }

    public void Start()
    {
        ChangeState( _default );
    }

    protected override void OnSave( Data data )
    {
        data.GameLogicSerialisable = _glSerialisable;
    }

    protected override void OnLoad( Data data )
    {
        _glSerialisable = data.GameLogicSerialisable;
    }


    public void Update()
    {
        if ( CurrentState != null )
        {
            CurrentState.Update();
        }
    }

    private void ChangeState( GameState state )
    {
        if ( CurrentState != null )
        {
            CurrentState.Exit();
        }

        CurrentState = state;

        CurrentState.Enter();
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
        Counter++;
    }

    public void DecrementCounter()
    {
        Counter--;
    }
}

public class GameLogicSerialisable
{
    public int Counter { get; set; }

    public GameState CurrentState { get; set; }
}
