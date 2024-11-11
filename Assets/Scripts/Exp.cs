
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class Exp : MonoBehaviour
{
    public Player player; // Ссылка на игрока
    public float attractionSpeed = 3.0f; // Скорость притяжения монетки к игроку
    public float lol;
    public ParticleSystem particleEffect;
    public GameObject go;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public TextMeshProUGUI _text2;  
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            
            player.GetComponent<Player>();
            player.AddExp(1);
            Destroy(gameObject); 
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }
    }
    void Update()
    {
       
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer < 4) // Расстояние, при котором монетка начнет притягиваться
        {
            Vector3 moveDirection = directionToPlayer.normalized;
            Vector3 newPosition = transform.position + moveDirection * attractionSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

}

