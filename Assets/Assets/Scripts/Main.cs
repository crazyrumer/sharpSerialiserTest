using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Polenter.Serialization;

public class Main : Manager<Main>
{
    [SerializeField]
    private bool _loadOnStart = false;

    private GameLogic _gameLogic = null;
    public GameLogic GameLogic { get { return _gameLogic; } }

    protected override void Awake()
    {
        base.Awake();

        _gameLogic = new GameLogic();

        if ( _loadOnStart )
        {
            PersistenceManager.Instance.Load();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void Start()
    {
        _gameLogic.Start();    
    }

    private void Update()
    {
        _gameLogic.Update();
    }

    void OnGUI()
    {
        if ( GUI.Button( new Rect( 100, 100, 100, 40 ), "Save" ) )
        {
            PersistenceManager.Instance.Save();
        }

        if ( GUI.Button( new Rect( 100, 150, 100, 40 ), "Load" ) )
        {
            PersistenceManager.Instance.Load();
        }

        if ( GUI.Button( new Rect( 100, 200, 100, 40 ), "Default" ) )
        {
            _gameLogic.ChangeToDefault();
        }

        if ( GUI.Button( new Rect( 100, 250, 100, 40 ), "Increment" ) )
        {
            _gameLogic.ChangeToIncrement();
        }

        if ( GUI.Button( new Rect( 100, 300, 100, 40 ), "Decrement" ) )
        {
            _gameLogic.ChangeToDecrement();
        }

        GUI.Label( new Rect( 100, 350, 100, 50 ), "Counter: " + _gameLogic.Counter );
        if ( _gameLogic.CurrentState != null )
        {
            GUI.Label( new Rect( 100, 400, 100, 50 ), "Current State: " + _gameLogic.CurrentState.Name );
        }
    }
}

