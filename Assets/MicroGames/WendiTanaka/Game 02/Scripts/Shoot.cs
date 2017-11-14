using UnityEngine;
using System.Collections;

namespace WendiTanaka
{
    public class Shoot : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;
        public Camera cam;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shooting();
            }
        }
        void Shooting()
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}