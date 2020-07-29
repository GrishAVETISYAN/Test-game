using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Animation_char : MonoBehaviour
{   
    public UnityArmatureComponent anim;

     /*void Start() 
    {
        animation_player("walk", 0, 2);     
    }
    */

    void animation_player(string name, int playTime, float speed)
    {
        anim.animation.timeScale = speed;
        anim.animation.Play(name, playTime);
    }

}
