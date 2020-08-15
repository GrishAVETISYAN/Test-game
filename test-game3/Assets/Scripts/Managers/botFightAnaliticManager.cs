using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botFightAnaliticManager : MonoBehaviour
{
    public GameObject Target;
    botManager BM;
    int presentSituation = 0;

    //0 - ban chi anum
    //1 - gnuma depi trvac ket
    //2 - gnal target chari pointneric meki mot
    //3 - attacka-a ani
    
    void Start()
    {
        BM = GetComponent<botManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            presentSituation = 2;
            changeSituatin();
        }
        if (Input.GetKeyUp("space"))
        {
            presentSituation = 0;
            changeSituatin();
        }

        if (Input.GetKeyDown("m"))
        {
            presentSituation = 3;
            changeSituatin();
        }
        if (Input.GetKeyUp("m"))
        {
            presentSituation = 0;
            changeSituatin();
        }
    }

    void changeSituatin()
    {
        GameObject TargetPoint;
        if (Target.tag == "Char")
            TargetPoint = Target.GetComponent<charFightPlease>().getPoint(gameObject);
        else
            TargetPoint = Target;

        BM._setPresentSituation(presentSituation, TargetPoint,Target);
    }
}
