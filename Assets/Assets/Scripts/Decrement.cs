using UnityEngine;
using System.Collections;

public class Decrement : GameState
{
    private string _name = "Decrement";
    public override string Name { get { return _name; } }

    // required by serializer
    public Decrement()
    { }


    public override void Update()
    {
        GameLogic.DecrementCounter();
    }
}
