using UnityEngine;
using System.Collections;

public class Data
{

    private GameLogicContainer _gameLogicContainer = null;
    public GameLogicContainer GameLogicContainer { get { return _gameLogicContainer; } set { _gameLogicContainer = value; } }

    public Data()
    {
        _gameLogicContainer = new GameLogicContainer();
    }

}

public class GameLogicContainer
{
    public int Counter { get; set; }
    public GameState CurrentState { get; set; }
}
