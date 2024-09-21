using System;
using System.Collections.Generic;
using System.Linq;
using Game.Enum;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameBoardUI:MonoBehaviour
    {
        //Move to Config Class
        [SerializeField] private GameObject _boardTilePrefab;
        //Move to config class
        [SerializeField] private GameObject[] _boardItems;
        [SerializeField] private Transform _leftUpperCornerTransform;
        [SerializeField] private Transform _rightBottomCornerTransform;
        [SerializeField] private Transform _currentTileTransform;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private int _boardWidth = 10;
        [SerializeField] private int _boardHeight = 10;
        private BoardTile[,] _boardTiles;
        private GameObject[,] _boardTilesView;
        private float _widthInUnits;
        private float _heightInUnits;
        private float _tileWidth;
        private float _tileHeight;
        private Vector3 _initialPosition;

        
        private void Awake()
        {
            InitializeBoardViewBouds();
        }
        
        [Button]
        public void Init()
        {
            InitBoardWithItems();
        }
        
        private void InitBoardWithItems()
        {
            _boardTiles = new BoardTile[_boardHeight,_boardWidth];
            _boardTilesView = new GameObject[_boardHeight,_boardWidth];
            for (int indexRow = 0; indexRow < _boardHeight; indexRow++)
            {
                string output = "";
                for (int indexCols = 0; indexCols < _boardWidth ;indexCols++)
                {
                    _boardTiles[indexRow, indexCols] = new BoardTile()
                    {
                        ItemType = (ItemTypeEnum) (Random.Range(1, 6)),
                        Checked = false,
                    };
                    output += $"{((int) _boardTiles[indexRow, indexCols].ItemType)}   ";
                    InitBoardView(indexRow, indexCols);
                    
                }

                output += ("\n");
                Debug.Log(output);
                
            }

        }

        private void InitBoardView(int indexRow, int indexCols)
        {
            Vector3 nextPosition = new Vector3(_initialPosition.x + indexCols * _tileWidth,
                _initialPosition.y - indexRow * _tileHeight, _initialPosition.z);
            //_currentTileTransform.position = nextPosition;

            _boardTilesView[indexRow, indexCols] = Instantiate(_boardTilePrefab);
            PositionRectTransform(_parentTransform,nextPosition,_boardTilesView[indexRow,indexCols].GetComponent<RectTransform>());
        }

        public void InitializeBoardViewBouds()
        {
            _widthInUnits = _rightBottomCornerTransform.position.x - _leftUpperCornerTransform.position.x;
            _heightInUnits = _leftUpperCornerTransform.position.y - _rightBottomCornerTransform.position.y;
            _tileWidth = _widthInUnits / _boardWidth;
            _tileHeight = _heightInUnits / _boardHeight;
            _initialPosition = new Vector3(_leftUpperCornerTransform.position.x + _tileWidth / 2, _leftUpperCornerTransform.position.y - _tileHeight/2, _leftUpperCornerTransform.position.z);
        }
        
        public void PositionRectTransform(Transform parentTransform,Vector3 nextPosition, RectTransform targetRectTransform)
        {
            targetRectTransform.SetParent(parentTransform.transform);
            targetRectTransform.anchoredPosition.Set(0, 0);
            targetRectTransform.anchorMin.Set(0, 0);
            targetRectTransform.anchorMax.Set(0, 1);
            targetRectTransform.pivot.Set(0, 0);
            targetRectTransform.transform.localPosition = nextPosition;
        }


    }
}

