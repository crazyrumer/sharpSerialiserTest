using UnityEngine;
using System.Collections;

public class Decrement : GameState
{
    private string _name = "Decrement";
    public override string Name { get { return _name; } }

    private GameLogic _gameLogic  = null;

    public Decrement( GameLogic gameLogic )
        : base( gameLogic )
    { }

    // required by serializer
    public Decrement()
    { }


    public override void Update()
    {
        GameLogic.DecrementCounter();
    }
}
