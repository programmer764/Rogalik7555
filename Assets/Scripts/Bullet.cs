using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;
   
   private Player _player;
    [SerializeField] private ParticleSystem particleEffect;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_player._damage);
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
private void Start()
    {
       
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _damage = _player._damage;
        // �������� ������� ���� � ����
        int bulletLayer = LayerMask.NameToLayer("Bullet");

        // ��������� ���� ������������� �������� ����� ��������� � ���������� ����� 666
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


