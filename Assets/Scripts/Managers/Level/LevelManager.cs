using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesNumberStart = 3;
    public int piecesNumber = 5;
    public int piecesNumberEnd = 1;

    public float timeBetweenPieces = .3f;

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
        
        for (int i = 0; i < piecesNumberStart; i++)
        {
            CreateLevelPieces(levelPiecesStart);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPieces(levelPieces);
        }

        for (int i = 0; i < piecesNumberEnd; i++)
        {
            CreateLevelPieces(levelPiecesEnd);
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
