using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BulletPool : MonoBehaviour
{
    public List<Bullet> bulletInUse = new List<Bullet>();
    public List<Bullet> bulletToUse = new List<Bullet>();

    public Bullet bulletPrefab = null;
    public AudioClip BulletSound = null;
    public GameObject BulletImpact = null;
    public AudioSource source = null;

    [HideInInspector]
    public UnityEvent<Vector3> OnDropBullet;

    private void Awake()
    {
        OnDropBullet.AddListener(PlayFX);
    }

    public Bullet GetBullet(Vector3 pos, Quaternion identity)
    {
        Bullet bullet;

        if (bulletToUse.Count > 0)
        {
            bullet = bulletToUse[0];
            bullet.transform.position = pos;
            bullet.transform.rotation = identity;
            bulletToUse.Remove(bullet);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, pos, identity);
            bullet.pool = this;
        }
        
        bulletInUse.Add(bullet);
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void DropBullet(Bullet bullet)
    {
        bulletInUse.Remove(bullet);
        bulletToUse.Add(bullet);
        bullet.gameObject.SetActive(false);
        OnDropBullet?.Invoke(bullet.transform.position);
    }

    public void PlayFX(Vector3 pos)
    {
        source.PlayOneShot(BulletSound);
        GameObject go = Instantiate(BulletImpact, pos, Quaternion.identity);
        Destroy(go, 0.5f);
    }

}
