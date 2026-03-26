using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPosition;

    void fireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        bullet.transform.position = launchPosition.position;

        bullet.GetComponent<Rigidbody>().linearVelocity =
            transform.parent.forward * 100;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
    }
}