using UnityEngine;
using System.Collections;

public class BaseClass
{
    public BaseClass()
    {
        RegisterListener();
    }
    private void RegisterListener()
    {
        PersistenceManager.Instance.RegisterPersistentObject( this );
    }

    private void DeregisterListener()
    {
        PersistenceManager.Instance.DeregisterPersistentObject( this ); 
    }

    public void Save( Data data)
    {
        OnSave( data );
    }

    public void Load(Data data)
    {
        OnLoad( data );
    }

    protected virtual void OnSave( Data data )
    { 
    }

    protected virtual void OnLoad( Data data )
    { 
    }
}
