using UnityEngine;
using System.Collections;

public class Increment : GameState
{
    private string _name = "Increment";
    public override string Name { get { return _name; } }

    public Increment()
    { }

    public override void Update()
    {
        GameLogic.IncrementCounter();
    }
}
