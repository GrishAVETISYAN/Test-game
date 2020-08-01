using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayFindBlock : MonoBehaviour
{

    void Start()
    {
        sendBlock();
    }

    void sendBlock()
    {
        wayFindPositionSystem Base = Camera.main.GetComponent<wayFindPositionSystem>();

        Base._setClosesTrue((int)transform.position.x, (int)transform.position.y);

    }
    
}
