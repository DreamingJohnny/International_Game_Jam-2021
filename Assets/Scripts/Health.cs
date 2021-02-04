using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Properties")]
    public float maxHealth;
    public float currentHealth;

    [Header("Reference")]
    public HealthBar healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void ModifyHealth(float damage)
    {
        currentHealth += damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            if (gameObject.CompareTag("Zombie"))
            {
                AudioManager.INSTANCE.PlaySound("Zombie Death", gameObject.transform.position);
            }

            if (gameObject.CompareTag("Enemy"))
            {
                CurrencyManager.Instance.ModifyCurrency(10);
                AudioManager.INSTANCE.PlaySound("Coin", gameObject.transform.position);
                AudioManager.INSTANCE.PlaySound("Banker Death", gameObject.transform.position);

            }

            if (gameObject.tag == "EnemyBase")
            {
                GameManager.Instance.WinGame();
            }
            else if (gameObject.tag == "Homebase")
            {
                GameManager.Instance.LoseGame();
            }
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}