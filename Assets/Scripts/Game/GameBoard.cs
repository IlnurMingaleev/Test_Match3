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
    public class GameBoard:MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        private const int _boardWidth = 10;
        private int _boardHeight = 10;
        private BoardTile[,] _boardTiles;

        [Button]

        public void Init()
        {
            InitBoardWithItems();
        }
        
        private void InitBoardWithItems()
        {
            _boardTiles = new BoardTile[_boardHeight,_boardWidth];
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
                    
                }

                output += ("\n");
                Debug.Log(output);
                
            }

        }

        public void DestroyItem(int indexRow, int indexCols)
        {
            
        }


    }
}

