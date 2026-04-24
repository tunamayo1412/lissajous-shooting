using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    bool hit;
    float originspeed = 0.3f;
    float speed;
    float xvec = 0;
    float yvec = 0;
    float width = 12f;
    float height = 19.5f;
    bool isShooting = false;
    float delta = 0;
    float span = 0.1f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject retrytext;
    AudioSource[] audio_sources;
    AudioSource bgm, hit_sound;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        speed = originspeed;
        audio_sources = GetComponents<AudioSource>();
        bgm = audio_sources[0];
        hit_sound = audio_sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (hit && Input.GetKeyDown(KeyCode.R))
        {
            panel.SetActive(false);
            retrytext.SetActive(false);
            bgm.volume = 0.6f;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        delta += Time.deltaTime;
        xvec = Input.GetAxis("Horizontal");
        yvec = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed = originspeed / 3;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed = originspeed;
        if (Input.GetKey(KeyCode.Z)) isShooting = true; else isShooting = false;
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + xvec * speed, -width / 2, width / 2);
        pos.y = Mathf.Clamp(pos.y + yvec * speed, -height / 2, height / 2);
        if (isShooting && delta >= span)
        {
            GameObject bul = Instantiate(bullet);
            bul.transform.position = transform.position + new Vector3(0, 1, 0);
            delta = 0;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            Time.timeScale = 0;
            hit_sound.Play();
            bgm.volume = 0.5f;
            hit = true;
            panel.SetActive(true);
            retrytext.SetActive(true);
        }
    }
}
