using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WendiTanaka
{
    public class Target : MonoBehaviour
    {
        public float amountToMoveX;
        public float speed;
        private float currentPosX;
        private bool move;

        void Start()
        {
            currentPosX = gameObject.transform.position.x; // getting original position of x
            move = true;
        }

        void Update()
        {
            // checking the move condition, and check the gameobject position if its less then the original position - the amount it moved
            if (move == true && gameObject.transform.position.x < currentPosX - amountToMoveX)
            {
                move = false;
            }
            // checking the move condition, and check the gameobject position if its more then the original position
            if (move == false && gameObject.transform.position.x > currentPosX)
            {
                move = true;
            }
            // move the environment to the right
            if (move == false)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            // move the environment to the left
            else if (move == true)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
        }
        public void Shot()
        {
            StirlingMulvey.GlobalGameManager.gameWon = true;
        }
    }
}