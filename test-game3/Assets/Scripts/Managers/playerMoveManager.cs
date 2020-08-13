using UnityEngine;

public class playerMoveManager : MonoBehaviour
{
    charMove CM;
    playerControll PC;
    serializedVector SV;
    charPhisicalMove CPM;
    charCollision CCs;

    bool isMoved = false;
    bool side = false;

    void Start()
    {

        CM = GetComponent<charMove>();
        PC = GetComponent<playerControll>();
        SV = GetComponent<serializedVector>();
        CPM = GetComponent<charPhisicalMove>();
        CCs = GetComponent<charCollision>();

        SV._doBegin();
        CPM._doBegin();
        CCs._doBegin();

    }

    
    void Update()
    {
        Vector2 CC_moveVector = CPM._GetMoveVector(PC._getVector());
        CM._doMove(CC_moveVector);
        SV._doSerializedVector(CC_moveVector);




        if (CC_moveVector == new Vector2(0, 0)) isMoved = false;
        else isMoved = true;
        side = PC._getSide();
        


        
    }

    public bool getIsMoved()
    {
        return (isMoved);
    }
    public bool getSide()
    {
        return (side);
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
