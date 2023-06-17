/*using Chess.Scripts.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum PieceType { Pawn, Knight, King, Queen, Bishop, Rook }

    public PieceType type;
    public bool isWhite;

    public virtual List<Vector2Int> GetLegalMoves(int currentRow, int currentColumn)
    {
        List<Vector2Int> legalMoves = new List<Vector2Int>();

        // Default implementation (can be overridden in derived classes)
        return legalMoves;
    }

    protected bool CheckMoveAndAdd(int row, int col, List<Vector2Int> legalMoves)
    {
        if (row >= 0 && row < 8 && col >= 0 && col < 8)
        {
            ChessPiece chessPiece = GetChessPieceAtTile(row, col);
            if (chessPiece == null)
            {
                legalMoves.Add(new Vector2Int(row, col));
                return true; // Continue checking in this direction
            }
        }
        return false; // Stop checking in this direction
    }

    public ChessPiece GetChessPieceAtTile(int row, int col)
    {
        ChessPiece[] chessPieces = FindObjectsOfType<ChessPiece>();

        foreach (ChessPiece chessPiece in chessPieces)
        {
            ChessPlayerPlacementHandler placementHandler = chessPiece.GetComponent<ChessPlayerPlacementHandler>();
            if (placementHandler != null && placementHandler.row == row && placementHandler.column == col)
            {
                return chessPiece;
            }
        }
        return null;
    }
}

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetLegalMoves(int currentRow, int currentColumn)
    {
        List<Vector2Int> legalMoves = new List<Vector2Int>();

        if (currentRow < 7)
        {
            if (CheckMoveAndAdd(currentRow + 1, currentColumn, legalMoves))
            {
                ChessPiece leftChessPiece = GetChessPieceAtTile(currentRow + 1, currentColumn - 1);
                if (currentColumn > 0 && leftChessPiece != null)
                {
                    CheckMoveAndAdd(currentRow + 1, currentColumn - 1, legalMoves);
                }

                ChessPiece rightChessPiece = GetChessPieceAtTile(currentRow + 1, currentColumn + 1);
                if (currentColumn < 7 && rightChessPiece != null)
                {
                    CheckMoveAndAdd(currentRow + 1, currentColumn + 1, legalMoves);
                }
            }
        }

        return legalMoves;
    }
}

// Implement other chess piece classes (Knight, King, Queen, Bishop, Rook) in a similar manner.



*/