using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        private ChessPiece chessPiece;
        private List<Vector2Int> legalMoves;

        private void Start() {
            chessPiece = GetComponent<ChessPiece>();
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
        }

        private void OnMouseDown() {
            ClearHighlights();
            if (chessPiece != null) {
                legalMoves = chessPiece.GetLegalMoves(row, column);
                HighlightLegalMoves();
            }
        }

        private void HighlightLegalMoves() {
            if (legalMoves != null) {
                foreach (Vector2Int move in legalMoves) {
                    ChessBoardPlacementHandler.Instance.Highlight((int)move.x, (int)move.y);
                }
            }
        }
        private void ClearHighlights() {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }
    }
}
