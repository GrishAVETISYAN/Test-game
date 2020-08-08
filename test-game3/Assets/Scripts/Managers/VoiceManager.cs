using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private float delay;
    [SerializeField] private float pitch;
    [SerializeField] private float long_delay;
    SoundPlayer SP;

    void Start()
    {
       SP = GetComponent<SoundPlayer>();
       StartCoroutine(SP._doPlayVoice(text, delay, long_delay, pitch));
       
    }
}

