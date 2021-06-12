using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceNormal : Piece
{
    public override void SetPieceType()
    {
        _pieceType = Enums.Piece.NONE;
    }
    
    public override void ResolveJointConnection(Collision2D p_other)
    {

    }

    public override void ConnectJoint(Collision2D p_other)
    {
        
    }
}
