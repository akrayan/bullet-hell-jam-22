using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float BulletForce = 100;
    [SerializeField] private float FireRate = 0.1f;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject CrossAir;
    [SerializeField] private Transform GunTransform;

    private PlayerInput pi;
    private Transform bulletOutput;
    private float chrono;
    // Start is called before the first frame update
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        pi.onPressShoot += onPressShoot;
        bulletOutput = GunTransform.Find("BulletOutput").transform;
        chrono = Time.time - FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossAir)
            CrossAir.transform.position = pi.pointAt;
        Utils2D.LookAt2D(GunTransform, pi.pointAt);
    }

    void onPressShoot()
    {
        if (Time.time - chrono > FireRate)
        {
            Vector2 dir = new Vector2(pi.pointAt.x - GunTransform.position.x, pi.pointAt.y - GunTransform.position.y);
            GameObject bullet = Instantiate(BulletPrefab, bulletOutput.position, bulletOutput.rotation);
            bullet.GetComponent<Rigidbody2D>()?.AddForce(dir.normalized * BulletForce);
            chrono = Time.time;
        }
    }
}
