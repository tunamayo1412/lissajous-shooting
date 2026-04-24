using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float wait = 3;
    float delta = 0;
    string owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = gameObject.tag;
    }

    void Update()
    {
        delta += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(delta >= wait)
        {
            transform.Translate(0, speed, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(owner == "PlayerBullet")
        {
            if (collision.tag == "Wall" || collision.tag == "Enemy") Destroy(gameObject);
        }
        if(owner == "EnemyBullet")
        {
            if (collision.tag == "Wall") Destroy(gameObject);
        }
    }
}
