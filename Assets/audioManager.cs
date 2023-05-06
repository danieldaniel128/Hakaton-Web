using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    private void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            audio.Play();
        }
    }
}
