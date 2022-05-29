using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable // эти интрерфейсы позвол€ют перебиратб коллекции
                                                                     // IEnumerable - возвращает сслыку на перечислитель
                                                                     // IEnumerator - определ€ет функционал дл€ перебора эл-тов
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;

        public object Current => _interactiveObject[_index];// Current - получение текущего эл-та
        public int Length => _interactiveObject.Length;
       
        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }

        public void AddExecuteObject(IExecute execute)
        {
            if(_interactiveObject == null)// провер€ем массив
            {
                _interactiveObject = new[] { execute };// если массив Null(в нем ничего нет) то создаем новый массив и добавл€ем в него execute
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);// если в массиве что-то есть
            _interactiveObject[Length - 1] = execute;// и добавл€ем в последнюю позицию
        }

        public bool MoveNext() //премещает указатель на тек-ций эл-т на следущую позицию в последовательности и провер€ет не закончилась ли коллекци€
        {
            if(_index == Length - 1)
            {
                Reset();
                return false;// если последовательность закончилась, MoveNext возвращает false
            }
            return true; 
        }

        public void Reset()// перемещение в начало в коллекции
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
