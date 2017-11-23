using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace WendiTanaka
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed = 20f;
        public float shootRate = 0.2f;
        public int bulletAmount = 3;

        private float shootTimer = 0f;
        private Text text;

        void Shoot()
        {
            GameObject clone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // instantiate bullet
            Rigidbody rigid = clone.GetComponent<Rigidbody>(); // get bullet(clone)'s rigidbody component
            rigid.AddForce(-transform.right * bulletSpeed, ForceMode.Impulse); // adding force, impulse mode for instant shoot?
        }
        void Update()
        {
            shootTimer += Time.deltaTime; // adding shootTimer with delta time, in order to compare it with shootRate 
            if (shootTimer > shootRate)
            {
                if (bulletAmount > 0) // if have bullet then you can shoot
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Shoot();
                        shootTimer = 0; // reset shoot timer so, it will count again from zero until shootTimer > shootRate
                        bulletAmount--;
                    }
                }
                else // else you lose
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        StirlingMulvey.GlobalGameManager.gameWon = false;
                }
            }
            text.text = bulletAmount.ToString();
        }
        void Start()
        {
            text = GameObject.Find("BulletText").GetComponent<Text>();
        }
    }
}