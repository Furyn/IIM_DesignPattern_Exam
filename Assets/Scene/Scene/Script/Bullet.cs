using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;
    [HideInInspector] public BulletPool pool = null;

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        return this;
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }
    
    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        if (collision.TryGetComponent<IHealth>(out IHealth health))
        {
            health?.TakeDamage(Power);
            pool.DropBullet(this);
        }
        else if (collision.TryGetComponent<ITouchable>(out ITouchable touch))
        {
            touch.Touch(0);
            pool.DropBullet(this);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        if (collision.collider.TryGetComponent<IHealth>(out IHealth health))
        {
            health?.TakeDamage(Power);
            pool.DropBullet(this);
        }
        else if (collision.collider.TryGetComponent<ITouchable>(out ITouchable touch))
        {
            touch.Touch(0);
            pool.DropBullet(this);
        }
    }

    private void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }
}
