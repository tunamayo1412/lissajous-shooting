using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] GameObject bullet_1, bullet_2, bullet_3;
    [SerializeField] Slider hp_bar;
    [SerializeField] Animator cutin;
    [SerializeField] ClearScript clear;
    AudioSource[] audio_sources;
    AudioSource damageSE;
    AudioSource spellcard;
    SpriteRenderer sprite;
    int HP = 150;
    int mode = 0;
    float delta = 0;
    float span = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        audio_sources = GetComponents<AudioSource>();
        damageSE = audio_sources[0];
        spellcard = audio_sources[1];
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        hp_bar.value = HP / 150f;
        if (HP <= 0)
        {
            mode++;
            if (mode < 3)
            {
                HP = 150;
                cutin.Play("Fade", 0, 0.0f);
                spellcard.Play();
            }
            else
            {
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
                foreach (GameObject bullet in bullets) Destroy(bullet);
                clear.Clear();
                Destroy(gameObject);
            }
        }
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(0.5f * Mathf.Cos(3 * Time.realtimeSinceStartup), 0.2f * Mathf.Sin(2 * Time.realtimeSinceStartup) + 5, 0);
        if (delta >= span)
        {
            switch (mode)
            {
                case 0:
                    bullethell(bullet_1, 4, 4, 5, 4);
                    break;
                case 1:
                    bullethell(bullet_1, 4, 4, 5, 4);
                    bullethell(bullet_2, 5, 5, 12, 4, 0.4f, 0.4f);
                    break;
                case 2:
                    bullethell(bullet_1, 4, 4, 4, 12);
                    bullethell(bullet_2, 5, 5, 12, 4, 0.6f, 0.6f);
                    bullethell(bullet_3, 8, 6, -4, -8, 2, 2);
                    break;
            }
            delta = 0;
        }
    }

    void bullethell(GameObject bullet, float width = 1, float height = 1, float xcycle = 1, float ycycle = 1, float xdensity = 1, float ydensity = 1)
    {
        GameObject bul = Instantiate(bullet);
        bul.transform.position = new Vector3(width * Mathf.Cos(xcycle * Time.realtimeSinceStartup), height * Mathf.Sin(ycycle * Time.realtimeSinceStartup) + 5, 0);
        bul.transform.Rotate(0, 0, 360 * Mathf.Cos(Time.realtimeSinceStartup / xdensity) * Mathf.Sin(Time.realtimeSinceStartup / ydensity));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            HP -= 1;
            damageSE.Play();
        }
    }
}
