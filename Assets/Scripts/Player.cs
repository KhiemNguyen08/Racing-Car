using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public bool isDead;
    public float limitx;
    public GameObject expVfx;
    Rigidbody2D m_rb;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isDead || !GameManager.Ins.isGameplaying) return;
        if (GamePadControoler.Ins.CanMoveLeft)
        {
            m_rb.velocity = Vector2.left * moveSpeed;
        }
        else if (GamePadControoler.Ins.CanMoveRight)
        {
            m_rb.velocity = Vector2.right * moveSpeed;
        }
        else
        {
            m_rb.velocity = Vector2.zero;
        }
        if (transform.position.x < -limitx)
        {
            transform.position = new Vector3(-limitx, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > limitx)
        {
            transform.position = new Vector3(limitx, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(COnst.OBSTACLE_TAG))
        {
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
            isDead = true;
            if(expVfx)
            Instantiate(expVfx, transform.position, Quaternion.identity);
            GameManager.Ins.Gameover();
        }

    }
}
