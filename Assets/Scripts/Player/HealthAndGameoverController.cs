using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HealthAndGameoverController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float unitDamage = 1f;
    public float healAmount = 30f;
    public SliderController healthSlider;
    public ScoreController scoreController;
    public GameObject postDestroyObject;

    public AudioSource backgroundMusic;
    public AudioSource collisionSound;
    public AudioSource pickUpSound;
    public AudioSource gameOverSound;
    public AnimationCurve deltaHealthToVolumeCurve;

    private float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
        healthSlider.SetNormalizedValue(currentHealth / maxHealth);
    }

    public void TakeDamageOnCollision(float impulse)
    {
        AddAndDisplayHealth(- impulse * unitDamage);
    }

    public void TakeHeal()
    {
        AddAndDisplayHealth(healAmount);
    }

    private void AddAndDisplayHealth(float deltaHealth)
    {
        currentHealth += deltaHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.SetNormalizedValue(currentHealth / maxHealth);

        if (currentHealth <= 0f)
        {
            backgroundMusic.Stop();
            gameOverSound.Play();
            GameOver();
        } else if (deltaHealth < 0f)
        {
            collisionSound.volume = deltaHealthToVolumeCurve.Evaluate(-deltaHealth);
            collisionSound.Play();
        } else
        {
            pickUpSound.Play();
        }
    }

    private void GameOver()
    {
        StaticValuesHolder.lastScore = scoreController.GetScore();
        scoreController.enabled = false;

        Instantiate(postDestroyObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
