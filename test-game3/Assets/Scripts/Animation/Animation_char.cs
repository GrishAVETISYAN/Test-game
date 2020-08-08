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

    public void _animation_player(string name, float speed, int playTime=0)
    {
        anim.animation.timeScale = speed;
        anim.animation.FadeIn(name, 0.5f, playTime);
    }

    public void _animation_flip(bool flip)
    {
        anim.armature.flipX = flip;
        
    }

}
