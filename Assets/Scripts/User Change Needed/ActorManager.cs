using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public enum ActorDatabase 
    {
        Aga = 1,
        Ricther = 2,
        Carrot = 3
    }

    public Dictionary<ActorDatabase, Transform> actorsLoaded = new Dictionary<ActorDatabase, Transform>();
    public static ActorManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    
    public void AddActor(ActorDatabase _key, Transform _value)
    {
        actorsLoaded.Add(_key, _value);
    }

    public Transform GetActor(ActorDatabase _key)
    {
        return actorsLoaded[_key];
    }
}
