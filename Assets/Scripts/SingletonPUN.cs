using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SingletonPUN<T> : MonoBehaviourPun where T : MonoBehaviourPun
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }

}
