using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorIdentification : MonoBehaviour
{
    [SerializeField] public ActorManager.ActorDatabase id;

    public void Start()
    {
        ActorManager.Instance.AddActor(id, transform);
    }
}
