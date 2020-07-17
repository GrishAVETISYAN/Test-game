using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControll : MonoBehaviour
{
    float sqrt2_2 = 0.70710678118f;
    

    public Vector2 _getVector()
    {
        Vector2 _moveVector = new Vector2(0,0);
        bool bW = Input.GetKey(KeyCode.W);
        bool bA = Input.GetKey(KeyCode.A);
        bool bS = Input.GetKey(KeyCode.S);
        bool bD = Input.GetKey(KeyCode.D);

        int trueCount = 0;
        if (bW) trueCount++;
        if (bA) trueCount++;
        if (bS) trueCount++;
        if (bD) trueCount++;

        if (trueCount == 0 || trueCount == 4) _moveVector = new Vector2(0, 0);
        else if (trueCount == 1 || trueCount == 3) _moveVector = new Vector2((bD ? 1 : 0) - (bA ? 1 : 0), (bW ? 1 : 0) - (bS ? 1 : 0));
        else if (trueCount == 2) _moveVector = new Vector2(sqrt2_2 * (bD ? 1 : 0) - sqrt2_2 * (bA ? 1 : 0), sqrt2_2 * (bW ? 1 : 0) - sqrt2_2 * (bS ? 1 : 0));
        return (_moveVector);
    }
}
