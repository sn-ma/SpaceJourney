using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HealthAndGameoverController : MonoBehaviour
{
    [Header("Health constants")]
    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private float unitDamage = 1f;

    [SerializeField]
    private float healAmount = 30f;

    [Header("Links")]
    [SerializeField]
    private SliderController healthSlider;

    [SerializeField]
    private ScoreController scoreController;

    [SerializeField]
    private GameObject postDestroyObject;

    [Header("Sounds")]
    [SerializeField]
    private AudioSource backgroundMusic;

    [SerializeField]
    private AudioSource collisionSound;

    [SerializeField]
    private AudioSource pickUpSound;

    [SerializeField]
    private AudioSource gameOverSound;

    [SerializeField]
    private AnimationCurve deltaHealthToVolumeCurve;

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
