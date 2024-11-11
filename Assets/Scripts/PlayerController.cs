using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
  
    public float attackRange = 1f;
    public LayerMask targetLayers;
    public int attackDamage = 10;
    public Animator _animator;    
    public GameObject bulletPrefab;
    public int _weapon = 1;
    private Player _player;
    [SerializeField] private Rigidbody2D rb;


    
    private SpriteRenderer spriteRenderer;
    

    public Transform hitPoint;
    public Transform hitPoint2;
    public Transform hitPoint3;
    public Transform hitPoint4;
    public Transform hitPoint5;
    public Transform currentHitPoint;
    public Transform BowHitPoint;
    private Vector3 direction;
    public float bulletSpeed;
    public int i, j;
    public bool IsAttacking;
    [SerializeField] private Animator _bow;
    private bool _shoot;
    public void Start()
    {
        _shoot = true;
        IsAttacking = false;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        j = 0;
        _player.HealthChanged?.Invoke(_player._flatHp);
        _player.ExpChanged?.Invoke(_player._exp,_player._maxExp);
        _player.MoneyChanged?.Invoke(_player._gold);
    }
    void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * _player._flatSpeed * Time.fixedDeltaTime);
    }
    public void Shoot1()
    {
        if (_shoot)
        {
            _bow.Play("Bow");
            _shoot = false;
            IEnumerator DelayedMethod(float delayInSeconds)
            {
                // Задержка
                yield return new WaitForSeconds(delayInSeconds);

                // Код, который нужно выполнить после задержки
                GameObject bullet = Instantiate(bulletPrefab, BowHitPoint.position, BowHitPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed;
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                _shoot = true;
            }
            StartCoroutine(DelayedMethod(0.2f));
        }
    }

    
    

    // Update is called once per frame
    private void ShootDrobovik()
    {
        for (int i = 0; i < 10; i++)
        {
            float angle2 = UnityEngine.Random.Range(-35f, 35f);//генерация угла для дробовика
            GameObject bullet = Instantiate(bulletPrefab, BowHitPoint.position, BowHitPoint.rotation);//создание префаба пули в текущем месте выстрела
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();//получение риджетбоди с префаба пули
            rb.velocity = Quaternion.AngleAxis(angle2, Vector3.forward) * direction * bulletSpeed ;//движение пули под рандомным углом в текущем направлении игрока
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;//вычисление угла префаба в зависимости от направления пули
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//задание направления угла префаба
            
        }
    }   

     


    void Update()
    {


        

            // Получаем позицию мыши в мировых координатах
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Находим направление от позиции игрока до позиции мыши
            direction = (mousePosition - (Vector2)transform.position).normalized;


            // Если нажата кнопка мыши, стреляем
            if (Input.GetButtonDown("Fire1"))
            {
            if (_weapon == 1 &&_player.canShoot)
                Shoot1(); _bow.Play("Bow");
            if (_weapon == 0 && _player.canShoot)
                ShootDrobovik();
        }

        

        if (Input.GetKey(KeyCode.W) && !IsAttacking)
        {
            i = 0;
            Move(Vector2.up);
            _animator.Play("Run");            
        }
        if (Input.GetKey(KeyCode.D) && !IsAttacking)
        {
            i = 1;
            Move(Vector2.right);
            spriteRenderer.flipX = false;            
            _animator.Play("Run");
        }
        if (Input.GetKey(KeyCode.A) && !IsAttacking)
        {
            i = 2;
            Move(Vector2.left);
            spriteRenderer.flipX = true;           
            _animator.Play("Run");
        }
        if (Input.GetKey(KeyCode.S) && !IsAttacking)
        {
            i = 3;
            Move(Vector2.down);
            _animator.Play("Run");           
        }   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsAttacking = true;
            IEnumerator DelayedMethod(float delayInSeconds)
            {
                // Задержка
                yield return new WaitForSeconds(delayInSeconds);

                // Код, который нужно выполнить после задержки
                IsAttacking = false;
            }
            StartCoroutine(DelayedMethod(0.5f));
            switch (i)
            {                
                case 0:
                    if (j == 1)
                    {
                        currentHitPoint = hitPoint;
                        Attack(); _animator.Play("AttackUp"); j = 0;
                    }
                    else if (j ==0)
                    {
                        currentHitPoint = hitPoint;
                        Attack(); _animator.Play("AttaclUp2"); j = 1;
                    }


                    break;
                case 1:
                    if (j == 1)
                    {
                        currentHitPoint = hitPoint2;
                        Attack(); _animator.Play("Attack"); j = 0;
                    }
                    else if (j == 0)
                    {
                        currentHitPoint = hitPoint2;
                        Attack(); _animator.Play("Attack2"); j = 1;
                    }
                    
                    break;
                case 2:

                    if(j == 1)
                    {
                        currentHitPoint = hitPoint3;
                        Attack(); _animator.Play("Attack"); j = 0;
                    }
                    else if (j == 0)
                    {
                        currentHitPoint = hitPoint2;
                        Attack(); _animator.Play("Attack2"); j = 1;
                    }
                    break;
                case 3:
                    if (j == 1)
                    {
                        currentHitPoint = hitPoint4;
                        Attack(); _animator.Play("AttackDown"); j = 0;
                    }
                    else if (j == 0)
                    {
                        currentHitPoint = hitPoint4;
                        Attack(); _animator.Play("AttackDown2"); j = 1;
                    }
                    break; 

            }

                        
            
        }
        


    }   
    void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(currentHitPoint.position, attackRange, targetLayers);
        foreach (Collider2D col in hitColliders)
        {                  
            if (col.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }



    
}
