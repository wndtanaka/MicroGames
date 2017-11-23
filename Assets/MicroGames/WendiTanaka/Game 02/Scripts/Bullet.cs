using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WendiTanaka
{
    public class Bullet : MonoBehaviour
    {
        public string triggerTag = "Target";
        void OnTriggerEnter(Collider col)
        {
            if (col.tag == triggerTag) // check target tag
            {
                Destroy(gameObject); // destroy bullet
                Destroy(col.transform.parent.gameObject); // destroy target
                StirlingMulvey.GlobalGameManager.gameWon = true; // if target destroy the game is won
            }
        }
    }
}