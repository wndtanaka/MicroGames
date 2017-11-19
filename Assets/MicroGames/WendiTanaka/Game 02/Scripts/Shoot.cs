using UnityEngine;
using System.Collections;

namespace WendiTanaka
{
    public class Shoot : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        Vector3 target;
        public Bullet bullet;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shooting();
            }
        }
        void Shooting()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                Target target = GetComponent<Target>();
                if (target != null)
                {
                    target.Shot();
                }
            }
            Vector3 targetPoint = ray.origin + (ray.direction * 10);
            target = targetPoint - transform.position;
            bullet.Fire(target);
        }
    }
}