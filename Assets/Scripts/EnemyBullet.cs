using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] public int _damage;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(1);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �������� ������� ���� � ����
        int bulletLayer = LayerMask.NameToLayer("Bullet");

        // ��������� ���� ������������� �������� ����� ��������� � ���������� �����
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer);
        IEnumerator DelayedMethod(float delayInSeconds)
        {
            // ��������
            yield return new WaitForSeconds(delayInSeconds);

            // ���, ������� ����� ��������� ����� ��������
            Destroy(gameObject);

        }
        StartCoroutine(DelayedMethod(1f));

    }
}

