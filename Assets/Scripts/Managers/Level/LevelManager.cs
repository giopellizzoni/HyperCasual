using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Level Pieces Base Setup")]
    public List<LevelPieceBaseSetup> pieceSetupList;

    private int _index;
    private GameObject _currentLevel;
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private LevelPieceBaseSetup _currentSetup;


    private void Start()
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
        //_currentLevel = Instantiate(levels[_index], container);
        //_currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevel()
    {
        _index = 0;
    }



    private void CreateLevel()
    {
        CleanSpawnedPieces();
        SpawnNextLevel();
        _currentSetup = pieceSetupList[_index];

        for (int i = 0; i < _currentSetup.piecesNumberStart; i++)
        {
            CreateLevelPieces(_currentSetup.levelPiecesStart);
        }

        for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPieces(_currentSetup.levelPieces);
        }

        for (int i = 0; i < _currentSetup.piecesNumberEnd; i++)
        {
            CreateLevelPieces(_currentSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorBy(_currentSetup.artType);
    }

    private void CreateLevelPieces(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;

        }
        else
        {
            spawnedPiece.transform.position = Vector3.zero;
        }

        foreach (var artPiece in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            artPiece.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }


}