using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    [SerializeField] private Transform hitPoint;
    [SerializeField] protected bool _shoot;
    [SerializeField] private GameObject bulletPrefab;
    protected Vector3 direction;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private float detectionRadius = 10f; // ������ ����������� ����
    [SerializeField] private float  _attackSpeed;
    void Start()
    {
        
        // �� ������ ���������������� ���-�� �����, ���� �����
    }

    void Update()
    {
        
    }

    protected void Shoot()
    {        
        if (_shoot)
        {
            _animator.Play("Bow");
            _shoot = false;

            IEnumerator DelayedMethod(float delayInSeconds)
            {
                yield return new WaitForSeconds(delayInSeconds);

                // �������� ����
                GameObject bullet = Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed; // ������������� �������� ����
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                _shoot = true; // ��������� ��������� �����
            }
            StartCoroutine(DelayedMethod(_attackSpeed));
        }
    }
    protected  void ShootDrobovik()
    {

        if (_shoot)
        {
            _animator.Play("Bow");
            _shoot = false;
            IEnumerator DelayedMethod(float delayInSeconds)
            {
                yield return new WaitForSeconds(delayInSeconds);

                // �������� ����
                for (int i = 0; i < 10; i++)
                {
                    float angle2 = UnityEngine.Random.Range(-35f, 35f);//��������� ���� ��� ���������
                    GameObject bullet = Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation);//�������� ������� ���� � ������� ����� ��������
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();//��������� ���������� � ������� ����
                    rb.velocity = Quaternion.AngleAxis(angle2, Vector3.forward) * direction * bulletSpeed;//�������� ���� ��� ��������� ����� � ������� ����������� ������
                    float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;//���������� ���� ������� � ����������� �� ����������� ����
                    bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//������� ����������� ���� �������

                }
                _shoot = true; // ��������� ��������� �����
            }
            StartCoroutine(DelayedMethod(_attackSpeed));
        }
        for (int i = 0; i < 10; i++)
        {
            float angle2 = UnityEngine.Random.Range(-35f, 35f);//��������� ���� ��� ���������
            GameObject bullet = Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation);//�������� ������� ���� � ������� ����� ��������
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();//��������� ���������� � ������� ����
            rb.velocity = Quaternion.AngleAxis(angle2, Vector3.forward) * direction * bulletSpeed;//�������� ���� ��� ��������� ����� � ������� ����������� ������
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;//���������� ���� ������� � ����������� �� ����������� ����
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//������� ����������� ���� �������

        }
    }

    protected GameObject FindNearestEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy")) // ���������, ���� ��� "Enemy"
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.gameObject;
                }
            }
        }

        return closestEnemy; // ���������� ���������� �����
    }
}
