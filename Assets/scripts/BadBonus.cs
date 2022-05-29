using System;

using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
namespace Maze
{
    public class BadBonus : Bonus, IRotation, Ifly
    {
        private float heigthFly;
        private float speedRotation;

        public event Action<string, Color> OnCaugthPlayer = delegate (string str, Color color) { };
        public void Awake()
        {
            _transform = GetComponent<Transform>();
            heigthFly = Random.Range(1f, 5f);
            speedRotation = Random.Range(13f, 40f);
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heigthFly) ,_transform.position.z);
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
        }
        public  override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {
            OnCaugthPlayer.Invoke(gameObject.name, _color);
        }
    }
}
