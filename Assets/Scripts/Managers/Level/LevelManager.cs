using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Level Pieces Base Setup")]
    public LevelPieceBaseSetup pieceSetup;
   
    private int _index;
    private GameObject _currentLevel;
    public List<LevelPieceBase> _spawnedPieces;

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevel();
    }

    private void SpawnNextLevel()
    {

        if (_currentLevel == null) 
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetLevel();
            }
        }  
        _currentLevel = Instantiate(levels[_index], container);    
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevel()
    {
        _index = 0;
    }



    private void CreateLevel() 
    {
        _spawnedPieces = new List<LevelPieceBase>();
        
        for (int i = 0; i < pieceSetup.piecesNumberStart; i++)
        {
            CreateLevelPieces(pieceSetup.levelPiecesStart);
        }

        for (int i = 0; i < pieceSetup.piecesNumber; i++)
        {
            CreateLevelPieces(pieceSetup.levelPieces);
        }

        for (int i = 0; i < pieceSetup.piecesNumberEnd; i++)
        {
            CreateLevelPieces(pieceSetup.levelPiecesEnd);
        }
    }

    private void CreateLevelPieces(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece =  _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
            
        }

        _spawnedPieces.Add(spawnedPiece);
    }


}
