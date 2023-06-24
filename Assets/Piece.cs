using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool isWhite;
    public bool isKing;
    public bool validMove(Piece[,] board, int x1, int y1, int x2, int y2){
        if(board[x2, y2] != null)
            return false;

        int deltaMove = Mathf.Abs(x1 - x2);
        int deltaMoveY = y1 - y2;
        if(isWhite || isKing){
            if(deltaMove == 1){
                if(deltaMoveY == 1)
                    return true;
            }
            else if(deltaMove == 2){
                if(deltaMoveY == 2){
                    Piece p = board[(x1 + x2)/2, (y1 + y2)/2];
                    if(p != null && p.isWhite != isWhite)
                        return true;
                }
            }
        } 
        return false;   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
