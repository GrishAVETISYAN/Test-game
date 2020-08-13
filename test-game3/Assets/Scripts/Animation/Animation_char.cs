using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Animation_char : MonoBehaviour
{   
    public UnityArmatureComponent anim;

     /*void Start() 
    {
        _animation_player("walk", 0, 2);     
    }
    */

    public void _animation_player(string name, float speed, int playTime, float fadeTime = 0.1f)
    {
        anim.animation.timeScale = speed;
        anim.animation.FadeIn(name, fadeTime, playTime);
    }

    public void _animation_flip(bool flip)
    {

        if (!flip)
        {
            anim.gameObject.transform.eulerAngles=new Vector3(0, 0, 0);
        }
        else
        {
            anim.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //anim.armature.flipX = flip;
        
    }

}
