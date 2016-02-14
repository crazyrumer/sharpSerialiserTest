using UnityEngine;
using System.Collections;

public class Default : GameState
{
    private string _name = "Default";
    public override string Name { get { return _name; } }

    private GameLogic _gameLogic  = null;

    public Default( GameLogic gameLogic )
        : base( gameLogic )
    { }

    public Default()
    { }
}
