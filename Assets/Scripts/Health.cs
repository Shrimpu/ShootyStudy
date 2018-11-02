using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private SpriteRenderer spriteR;
    Color hurtColor = new Color(255, 0, 0);
    private float colorOverwriteTime = 0.1f;
    private Coroutine hurt;
    public bool flashesRed = true;
    public GameObject drop;

    public AudioClip inPain;
    public AudioClip deathClip;

    private AudioSource AudioPain;
    private AudioSource AudioDeath;
    public GameObject animeDeath;

    [Header("Health")]
    [Range(1, 1000)]
    public int health;
    public bool invincible = false;
    public bool enemy;
    public bool boss;
    [Header("Damage on contact with")]
    private string targetTag;
    public float contactDamageRate;
    private float nextDamageInstance;
    [Header("Score")]
    public int scoreOnDeath;

    private void Start()
    {
        GetShit();
    }

    protected virtual void GetShit()
    {
        if (enemy)
        {
            targetTag = "PlayerProjectile";
        }
        else
        {
            targetTag = "Enemy";
        }

        spriteR = GetComponent<SpriteRenderer>();
        AudioPain = AddAudio(inPain, false, false, 0.1f);
        AudioDeath = AddAudio(deathClip, false, false, 1f);

        if (boss)
        {
            GameObject gc = GameObject.FindGameObjectWithTag("GameController");
            HealthBar healthBar = gc.GetComponent<HealthBar>();
            healthBar.SetBossHealth(gameObject.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (targetTag == "PlayerProjectile" && collision.gameObject.tag == targetTag)
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag && nextDamageInstance < Time.time)
        {
            TakeDamage(1);
            nextDamageInstance = Time.time + contactDamageRate;
        }
    }

    public virtual void TakeDamage(int bigHurt)
    {
        if (!invincible)
        {
            health -= bigHurt;
            if (health <= 0)
            {
                if (targetTag == "PlayerProjectile")
                {
                    GameObject gc = GameObject.FindGameObjectWithTag("GameController");
                    if (gc != null)
                    {
                        Score score = gc.GetComponent<Score>();
                        score.AddScore(scoreOnDeath);
                    }
                }
                Death();
            }
            else
            {
                if (flashesRed)
                {
                    if (hurt != null)
                        StopCoroutine(hurt);
                    hurt = StartCoroutine(ColorChange());
                }

                if (AudioPain != null)
                    AudioPain.Play(0);
            }

            if (targetTag == "Enemy")
            {
                GameObject gc = GameObject.FindGameObjectWithTag("GameController");
                HealthBar healthBar = gc.GetComponent<HealthBar>();
                healthBar.HealthBarCalc(bigHurt, false);
            }
            else if (boss)
            {
                GameObject gc = GameObject.FindGameObjectWithTag("GameController");
                HealthBar healthBar = gc.GetComponent<HealthBar>();
                healthBar.HealthBarCalc(bigHurt, true);
            }
        }
    }

    IEnumerator ColorChange()
    {
        Color fade = hurtColor;
        while (fade.g < 255)
        {
            fade.g += Time.deltaTime / colorOverwriteTime;

            if (fade.g >= 255f)
                fade.g = 255f;

            fade.b = fade.g;
            spriteR.color = fade;

            yield return null;
        }
        spriteR.color = fade;
    }

    protected void Death()
    {
        if (targetTag == "Enemy") // is player
        {
            GameObject gc = GameObject.FindGameObjectWithTag("GameController");
            Pause dead = gc.GetComponent<Pause>();
            dead.gameOver = true;
        }

        if (deathClip != null)
        {
            AudioDeath.Play(0);
            spriteR.enabled = false;
            if (gameObject.GetComponent<EnemyShoot>() != null)
                gameObject.GetComponent<EnemyShoot>().stopShooting = true;
            if (drop != null)
                Instantiate(drop, transform.position, Quaternion.identity);

            if (animeDeath != null)
            {
                Instantiate(animeDeath, transform.position, Quaternion.identity);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y + 10);
            if (targetTag != "Enemy")
                Destroy(gameObject, AudioDeath.clip.length);
        }
        else
        {
            if (targetTag != "Enemy")
                Destroy(gameObject);
        }

        invincible = true;
    }

    private AudioSource AddAudio(AudioClip clip, bool loop, bool playOnAwake, float volume)
    {
        var newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playOnAwake;
        newAudio.volume = volume;
        return newAudio;
    }

    public void SetHealthBar(int amount, bool boss)
    {
        GameObject gc = GameObject.FindGameObjectWithTag("GameController");
        HealthBar healthBar = gc.GetComponent<HealthBar>();

        if (!boss)
        {
            healthBar.fullHealth = amount;
            healthBar.curHealth = amount;
        }
        else
        {
            healthBar.bossFullHealth = amount;
            healthBar.bossCurHealth = amount;
        }
        healthBar.HealthBarCalc(0, boss);
    }
}