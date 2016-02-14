using UnityEngine;
using System.Collections;

public class Increment : GameState
{
    private string _name = "Increment";
    public override string Name { get { return _name; } }

    public Increment( GameLogic gameLogic )
        : base( gameLogic )
    {
    }

    public Increment()
    { }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        GameLogic.IncrementCounter();
    }
}
