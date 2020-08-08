using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{   
    [SerializeField] AudioSource source;
    
    [SerializeField] AudioClip sound;
    public IEnumerator _doPlayVoice(string text, float delay, float long_delay, float pitch)
    {
        string [] ts = text.Split(' '); 

        foreach(string st in ts )
        {
            for(int i = 0; i < st.Length; i++)
            {
                source.pitch = pitch + Random.Range(-0.05f, 0.05f);
                yield return new WaitForSeconds(delay);
                source.PlayOneShot(sound);
            }

            yield return new WaitForSeconds(long_delay);
        }
    } 
}
