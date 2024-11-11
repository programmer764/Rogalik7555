using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonedbullets : MonoBehaviour
{
    private float _damage;
    public float poisonDuration = 5f; // ������������ ����������
    public float poisonDamage = 1f; // ���� �� ��� � �������
    private Player _player;
    [SerializeField] private ParticleSystem particleEffect;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.PoisonDamage(5f, 2f);
            Instantiate(particleEffect, transform.position, Quaternion.identity);                    
        }

    }
   

    private void Start()
    {

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _damage = _player._damage;
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
