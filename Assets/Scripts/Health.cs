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

            if (gameObject.tag == "Enemybase")
            {
                GameManager.Instance.WinGame();
            }
            else if (gameObject.tag == "Homebase")
            {
                GameManager.Instance.LoseGame();
            }
        }
    }
}