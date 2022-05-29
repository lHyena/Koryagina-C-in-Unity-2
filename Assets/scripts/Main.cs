using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Maze
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject; 
        private InputController _inputController;

        [SerializeField]private BadBonus badBonus;

        [SerializeField] private GameObject _player;
        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());// ���������� � �������� ������ �� ��������
            _interactiveObject = new ListExecuteObject();// �������� ����� ������������� ��������

            _interactiveObject.AddExecuteObject(_inputController);// ��������� _inputController � ���� ����

            
            badBonus.OnCaugthPlayer += GameOver;
        }

        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color:" + color);
        }
        void Update()
        {
            for( int i= 0; i< _interactiveObject.Length; i++)
            {
                //_inputController.Update();
                if (_interactiveObject[i] == null)
                {
                    continue;
                }

                _interactiveObject[i].Update();
            }
        }
    }
}
