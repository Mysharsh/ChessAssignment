using Chess.Scripts.Core;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum PieceType { Pawn, Knight, King, Queen, Bishop, Rook }
    public PieceType type;
    public bool isWhite; // Whether the chess piece is white or black
    ChessPiece chessPiece;
    public List<Vector2Int> GetLegalMoves(int currentRow, int currentColumn)
    {
        List<Vector2Int> legalMoves = new List<Vector2Int>();

        // Add your logic here to calculate the legal moves for the chess piece

        switch (type)
        {
            case PieceType.Pawn:
                ChessPiece leftchessPiece = GetChessPieceAtTile(currentRow + 1, currentColumn - 1);
                ChessPiece rightchessPiece = GetChessPieceAtTile(currentRow + 1, currentColumn + 1);
                if (currentRow < 7 && GetChessPieceAtTile(currentRow + 1, currentColumn) == null)
                {
                    if(!CheckMoveAndAdd(currentRow + 1, currentColumn, legalMoves))break;
                    if (currentColumn > 0 && leftchessPiece != null)
                    {
                        //Debug.Log(rightchessPiece);
                        CheckMoveAndAdd(currentRow + 1, currentColumn - 1, legalMoves);
                    }

                    if (currentColumn < 7 && rightchessPiece != null)
                    {
                        CheckMoveAndAdd(currentRow + 1, currentColumn + 1, legalMoves);

                    }
                }
                
                break;

            case PieceType.Knight:
                // Assuming the knight moves in an L-shape

                if (!CheckMoveAndAdd(currentRow + 2, currentColumn + 1, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow + 2, currentColumn - 1, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow - 2, currentColumn + 1, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow - 2, currentColumn - 1, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow + 1, currentColumn + 2, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow + 1, currentColumn - 2, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow - 1, currentColumn + 2, legalMoves)) break;
                if (!CheckMoveAndAdd(currentRow - 1, currentColumn - 2, legalMoves)) break;

                break;

            case PieceType.Rook:
                for (int row = currentRow + 1; row < 8; row++)
                {
                    if (!CheckMoveAndAdd(row, currentColumn, legalMoves)) break;
                }
                for (int row = currentRow - 1; row >= 0; row--)
                {

                    if (!CheckMoveAndAdd(row, currentColumn, legalMoves)) break;
                }
                for (int col = currentColumn + 1; col < 8; col++)
                {
                    if (!CheckMoveAndAdd(currentRow, col, legalMoves)) break;
                }
                for (int col = currentColumn - 1; col >= 0; col--)
                {
                    if (!CheckMoveAndAdd(currentRow, col, legalMoves)) break;
                }
                break;

            case PieceType.King:
                for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
                {
                    for (int colOffset = -1; colOffset <= 1; colOffset++)
                    {
                        // Skip the current position
                        if (rowOffset == 0 && colOffset == 0)
                            continue;

                        int newRow = currentRow + rowOffset;
                        int newColumn = currentColumn + colOffset;

                        CheckMoveAndAdd(newRow, newColumn, legalMoves);
                    }
                }
                break;

            case PieceType.Queen:
                // Assuming the queen can move horizontally, vertically, and diagonally
                for (int i = 1; currentRow + i < 8 && currentColumn + i < 8; i++)
                {
                    if (!CheckMoveAndAdd(currentRow + i, currentColumn + i, legalMoves))
                        break;
                }

                for (int i = 1; currentRow + i < 8 && currentColumn - i >= 0; i++)
                {
                    if (!CheckMoveAndAdd(currentRow + i, currentColumn - i, legalMoves))
                        break;
                }

                for (int i = 1; currentRow - i >= 0 && currentColumn + i < 8; i++)
                {
                    if (!CheckMoveAndAdd(currentRow - i, currentColumn + i, legalMoves))
                        break;
                }

                for (int i = 1; currentRow - i >= 0 && currentColumn - i >= 0; i++)
                {
                    if (!CheckMoveAndAdd(currentRow - i, currentColumn - i, legalMoves))
                        break;
                }

                for (int row = currentRow + 1; row < 8; row++)
                {
                    if (!CheckMoveAndAdd(row, currentColumn, legalMoves))
                        break;
                }

                for (int row = currentRow - 1; row >= 0; row--)
                {
                    if (!CheckMoveAndAdd(row, currentColumn, legalMoves))
                        break;
                }

                for (int col = currentColumn + 1; col < 8; col++)
                {
                    if (!CheckMoveAndAdd(currentRow, col, legalMoves))
                        break;
                }

                for (int col = currentColumn - 1; col >= 0; col--)
                {
                    if (!CheckMoveAndAdd(currentRow, col, legalMoves))
                        break;
                }

                break;

            case PieceType.Bishop:
                // Assuming the bishop can move diagonally
                for (int i = 1; currentRow + i < 8 && currentColumn + i < 8; i++)
                {
                    if (!CheckMoveAndAdd(currentRow + i, currentColumn + i, legalMoves))
                        break;
                }

                for (int i = 1; currentRow + i < 8 && currentColumn - i >= 0; i++)
                {
                    if (!CheckMoveAndAdd(currentRow + i, currentColumn - i, legalMoves))
                        break;
                }

                for (int i = 1; currentRow - i >= 0 && currentColumn + i < 8; i++)
                {
                    if (!CheckMoveAndAdd(currentRow - i, currentColumn + i, legalMoves))
                        break;
                }

                for (int i = 1; currentRow - i >= 0 && currentColumn - i >= 0; i++)
                {
                    if (!CheckMoveAndAdd(currentRow - i, currentColumn - i, legalMoves))
                        break;
                }
                break;
        }


        return legalMoves;
    }
    private bool CheckMoveAndAdd(int row, int col, List<Vector2Int> legalMoves)
    {
        chessPiece = GetChessPieceAtTile(row, col);
        if (row >= 0 && row < 8 && col >= 0 && col < 8)
        {
            if (chessPiece == null)
            {
                legalMoves.Add(new Vector2Int(row, col));
                return true; // Continue checking in this direction
            }
            else
            {
                //legalMoves.Add(new Vector2Int(row, col)); // For enemy pieces and highlight red
                return false; // Stop checking in this direction
            }
        }
        return false;
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
