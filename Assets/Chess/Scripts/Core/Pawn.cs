/*using UnityEngine;

public class Pawn : ChessPiece
{
    public void OnMouseButtonDown()
    {
        
            // Get the name of the selected chess piece's GameObject
            string chessPieceName = gameObject.name;

            // Print the name in the console
            Debug.Log("Selected Chess Piece: " + chessPieceName);
        
    }
    protected override void CalculateAndHighlightMoves()
    {
        // Clear any previous highlights
        ChessBoardPlacementHandler.Instance.ClearHighlights();


        // Calculate possible moves for a pawn
        int forwardRow = currentRow + 1; // Assuming the pawn moves one row forward
        int forwardColumn = currentColumn;

        // Check if the forward move is valid and the tile is empty
        if (IsValidMove(forwardRow, forwardColumn) && IsEmptyTile(forwardRow, forwardColumn))
        {
            // Highlight the forward move
            ChessBoardPlacementHandler.Instance.Highlight(forwardRow, forwardColumn);

            // Check if the pawn is at its starting position
            if (currentRow == 1)
            {
                int doubleForwardRow = currentRow + 2; // Assuming the pawn moves two rows forward
                int doubleForwardColumn = currentColumn;

                // Check if the two-square forward move is valid and both tiles are empty
                if (IsValidMove(doubleForwardRow, doubleForwardColumn) && IsEmptyTile(doubleForwardRow, doubleForwardColumn) && IsEmptyTile(forwardRow, forwardColumn))
                {
                    // Highlight the two-square forward move
                    ChessBoardPlacementHandler.Instance.Highlight(doubleForwardRow, doubleForwardColumn);
                }
            }
        }

        // Calculate and highlight diagonal captures
        int captureRow1 = currentRow + 1; // Assuming the pawn moves one row forward and one column to the right
        int captureColumn1 = currentColumn + 1;

        int captureRow2 = currentRow + 1; // Assuming the pawn moves one row forward and one column to the left
        int captureColumn2 = currentColumn - 1;

        // Check if the diagonal captures are valid moves and the target tiles contain enemy pieces
        if (IsValidMove(captureRow1, captureColumn1) && HasEnemyPiece(captureRow1, captureColumn1))
        {
            // Highlight the diagonal capture to the right
            ChessBoardPlacementHandler.Instance.Highlight(captureRow1, captureColumn1);
        }

        if (IsValidMove(captureRow2, captureColumn2) && HasEnemyPiece(captureRow2, captureColumn2))
        {
            // Highlight the diagonal capture to the left
            ChessBoardPlacementHandler.Instance.Highlight(captureRow2, captureColumn2);
        }
    }

    private bool IsValidMove(int row, int column)
    {
        // Implement the logic to check if the given row and column indices represent a valid move for a pawn
        // Return true if it's a valid move, false otherwise
        // You can consider factors such as board boundaries and other game rules specific to pawn movement
        // Make sure to return an appropriate value based on your specific implementation
        // For now, we'll assume all moves are valid
        return true;
    }

    private bool IsEmptyTile(int row, int column)
    {
        // Implement the logic to check if the tile at the given row and column is empty
        // Return true if the tile is empty, false otherwise
        // Make sure to return an appropriate value based on your specific implementation
        // For now, we'll assume all tiles are empty
        return true;
    }

    private bool HasEnemyPiece(int row, int column)
    {
        // Implement the logic to check if the tile at the given row and column contains an enemy piece
        // Return true if the tile contains an enemy piece, false otherwise
        // Make sure to return an appropriate value based on your specific implementation
        // For now, we'll assume there are no enemy pieces
        return false;
    }
}*/