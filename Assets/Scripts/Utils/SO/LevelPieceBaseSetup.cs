using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    public int piecesNumberStart;
    public int piecesNumber;
    public int piecesNumberEnd;
}
