using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour // stay clear of this one if you wish to avoid PTSD
{
    private SpriteRenderer spriteR; // these variables are just everywhere. you can't find anything in this code withouth ctrl + f
    Color hurtColor = new Color(255, 0, 0);
    private float colorOverwriteTime = 0.1f;
    public Coroutine hurt;
    public bool flashesRed = true;
    public GameObject[] drop;
    public bool hasDrop;

    public AudioClip inPain;
    public AudioClip deathClip; // i made this sound by crushing an egg in my hand.

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
        GetShit(); // excuse my profanity
        SetDifficulty();
    }

    public void SetDifficulty()
    {
        if (gameObject.name == "Narwhal(Clone)")
        {
            SetHealth(2, 3, 5); // I like this. 2 = hp for Easy, 3 = hp for Normal, 5 = hp for Hard
        }
        else if (gameObject.name == "Swordfish(Clone)")
        {
            SetHealth(1, 2, 3);
        }
        else if (gameObject.name == "Lion Paw Clam(Clone)")
        {
            SetHealth(5, 10, 15);
        }
        else if (gameObject.name == "Alve FiskSpel(Clone)") // enemy made by my cousin Alve
        {
            SetHealth(5, 10, 15);
        }
        else if (gameObject.name == "PenguBoss(Clone)")
        {
            SetHealth(100, 100, 150);
        }
        else if (gameObject.name == "Shark(Clone)")
        {
            SetHealth(1000, 1000, 1000);
        }

        if (boss)
        {
            GameObject gc = GameObject.FindGameObjectWithTag("GameController");
            HealthBar healthBar = gc.GetComponent<HealthBar>();
            healthBar.SetBossHealth(gameObject.name); // gives name to something. this code is so tangled its hard to tell.
        }
    }

    private void SetHealth(int e, int n, int h) // e = easy, etc.
    {
        GameObject gc = GameObject.FindGameObjectWithTag("GameController");
        string difficulty = gc.GetComponent<Pause>().difficulty;

        if (difficulty == "Easy")
            health = e;
        else if (difficulty == "Normal")
            health = n;
        else if (difficulty == "Hard")
            health = h;
    }

    protected virtual void GetShit()
    {
        if (enemy) // this is very confusing
        {
            targetTag = "PlayerProjectile"; // this means the object is an enemy
        }
        else
        {
            targetTag = "Enemy"; // not an enemy.
        }

        spriteR = GetComponent<SpriteRenderer>();
        AudioPain = AddAudio(inPain, false, false, 0.1f); // this code is most definetly not ripped from somewhere else.
        AudioDeath = AddAudio(deathClip, false, false, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (targetTag == "PlayerProjectile" && collision.gameObject.tag == targetTag) // im sorry what?
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag && nextDamageInstance < Time.time) // this way you'll not die immediatley
        {
            TakeDamage(1);
            nextDamageInstance = Time.time + contactDamageRate;
        }
    }

    public virtual void TakeDamage(int bigHurt) // I don't claim to be the smartest
    {
        if (!invincible) // haxermode
        {
            health -= bigHurt; // bigHurt = damage from the enemy projectile
            if (health <= 0)
            {
                if (enemy)
                {
                    GameObject gc = GameObject.FindGameObjectWithTag("GameController"); // why didn't I just create this in the beginning? I use it so much.
                    if (gc != null)
                    {
                        Score score = gc.GetComponent<Score>();
                        score.AddScore(scoreOnDeath);
                    }
                }
                Death(); // can you spot the code that should've been in death?
            }
            else
            {
                if (flashesRed)
                {
                    if (hurt != null)
                        StopCoroutine(hurt);
                    hurt = StartCoroutine(ColorChange(hurtColor));
                }

                if (AudioPain != null)
                    AudioPain.Play(0);
            }

            if (!enemy) // player
            {
                GameObject gc = GameObject.FindGameObjectWithTag("GameController");
                HealthBar healthBar = gc.GetComponent<HealthBar>();
                healthBar.HealthBarCalc(bigHurt, false); // the false tells it im not a boss :(
            }
            else if (boss)
            {
                GameObject gc = GameObject.FindGameObjectWithTag("GameController");
                HealthBar healthBar = gc.GetComponent<HealthBar>();
                healthBar.HealthBarCalc(bigHurt, true);
            }
        }
    }

    public IEnumerator ColorChange(Color fade) // makes the object flash red
    {
        while (fade != Color.white)
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
        if (!enemy) // is player
        {
            GameObject gc = GameObject.FindGameObjectWithTag("GameController");
            Pause dead = gc.GetComponent<Pause>();
            dead.gameOver = true;
        }

        if (deathClip != null)
        {
            AudioDeath.Play(0);
            spriteR.enabled = false; // simulate death (i dont want to destory the object before playing sound)
            if (gameObject.GetComponent<EnemyShoot>() != null)
                gameObject.GetComponent<EnemyShoot>().stopShooting = true; // disables the phantom bullets
            if (hasDrop) // if (drop[0] != null) didn't work to well so fuck it
            {
                for (int i = 0; i < drop.Length; i++)
                {
                    Instantiate(drop[i], transform.position, Quaternion.identity); // look at all this wasted potential. I have a total of 1 enemy that drops an item after death
                }
            }
            if (animeDeath != null) // if death animation doesnt equal null
            {
                Instantiate(animeDeath, transform.position, Quaternion.identity);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y + 10);
            if (enemy)
                Destroy(gameObject, AudioDeath.clip.length); // kills object after some time
        }
        else
        {
            if (enemy)
                Destroy(gameObject);
        }

        invincible = true; // now it wont flash red to ruin the illusion of it actually dying.
    }

    private AudioSource AddAudio(AudioClip clip, bool loop, bool playOnAwake, float volume) // this isn't mine
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