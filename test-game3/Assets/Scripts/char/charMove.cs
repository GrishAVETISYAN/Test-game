using UnityEngine;

public class charMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public void _doMove(Vector2 moveVector)
    {

        Vector2 moveVectorTDT = new Vector2(moveVector.x*Time.deltaTime* moveSpeed, moveVector.y * Time.deltaTime* moveSpeed);//get speed move vector
        gameObject.transform.Translate(moveVectorTDT);//transform
        
    }
}
