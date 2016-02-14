using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Polenter.Serialization;
using System.Collections.Generic;

public class PersistenceManager : Manager<PersistenceManager>
{
    private List<BaseClass> _persistantObjects = new List<BaseClass>();

    private string Path { get { return Application.persistentDataPath + "/playerInfo.xml"; } }

    public interface Listener
    {
        void RegisterListener();
        void DeregisterListner();
        void Save( Data data );
        void Load( Data data );
    }

    protected override void Awake()
    {
        base.Awake(); // required by base class
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
 
    public void Save()
    {
        Data data = new Data();

        // Let all base objects know that it is time to save
        foreach ( BaseClass bc in _persistantObjects )
        {
            bc.Save( data );
        }

        SharpSerializer serialiser = new SharpSerializer();

        serialiser.Serialize( data,  Path);

        Debug.Log( " Saved data at: " + Path );
    }

    public void Load()
    {
        SharpSerializer serialiser = new SharpSerializer();

        Data data = new Data();

        if ( File.Exists( Path ) )
        {
            data = ( Data )serialiser.Deserialize( Path );

            foreach ( BaseClass bc in _persistantObjects )
            {
                bc.Load( data );
            }

            Debug.Log( " File Load success from: " + Path );

            return;
        }

        Debug.Log( " Could not load, file does not exist: " + Path );
    }

    public void RegisterPersistentObject( BaseClass persistentObject )
    {
        _persistantObjects.Add( persistentObject );
    }

    public void DeregisterPersistentObject( BaseClass persistentObject )
    {
        _persistantObjects.Remove( persistentObject );
    }
}
