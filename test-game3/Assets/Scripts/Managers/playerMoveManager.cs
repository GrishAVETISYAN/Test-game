using UnityEngine;

public class playerMoveManager : MonoBehaviour
{
    charMove CM;
    charControll CC;
    serializedVector SV;
    charPhisicalMove CPM;
    charCollision CCs;
    
    
    void Start()
    {

        CM = GetComponent<charMove>();
        CC = GetComponent<charControll>();
        SV = GetComponent<serializedVector>();
        CPM = GetComponent<charPhisicalMove>();
        CCs = GetComponent<charCollision>();

        SV._doBegin();
        CPM._doBegin();
        CCs._doBegin();

    }

    
    void Update()
    {   
       

        Vector2 CC_moveVector = CPM._GetMoveVector(CC._getVector());

        CM._doMove              (CC_moveVector);
        SV._doSerializedVector  (CC_moveVector);
    }


    public void _addComponentOnCharPhisicalMove(Vector2 norm)
    {
        CPM._addComponent(norm);
    }
    public void _deleteComponentOnCharPhisicalMove(Vector2 norm)
    {
        CPM._deleteComponent(norm);
        
    }
}
