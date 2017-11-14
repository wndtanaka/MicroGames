using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WendiTanaka
{
    public class EnvironmentMovement : MonoBehaviour
    {
        public float amountToMoveX;
        public float speed;
        private float currentPosX;
        private bool move;

        void Start()
        {
            currentPosX = gameObject.transform.position.x;
            move = true;
        }

        void Update()
        {
            if (move == true && gameObject.transform.position.x < currentPosX - amountToMoveX)
            {
                move = false;
            }

            if (move == false && gameObject.transform.position.x > currentPosX)
            {
                move = true;
            }

            if (move == false)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if (move == true)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
        }
    }
}