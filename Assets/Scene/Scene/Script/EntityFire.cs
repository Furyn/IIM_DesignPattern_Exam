using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] BulletPool _bulletPool;

    public bool canFire = true;

    public void FireBullet(int power)
    {
        if (!canFire)
            return;
        var b = _bulletPool.GetBullet(_spawnPoint.transform.position, Quaternion.identity)
            .Init(_spawnPoint.TransformDirection(Vector3.right), power);
    }

}
