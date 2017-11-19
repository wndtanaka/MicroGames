using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WendiTanaka
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed;
        public float damage = 10f;
        public Rigidbody rb;
        public void Fire(Vector3 target)
        {
            rb.AddForce(target * bulletSpeed * Time.deltaTime,ForceMode.Impulse);
        }
    }
}