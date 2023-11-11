using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootingDelay = 1;

    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(_shootingDelay);
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, _target.position, Quaternion.identity);

            bullet.SetVelocity(direction * _speed);

            yield return _delay;
        }
    }
}
