using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;
    public static CurrencyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CurrencyManager>();
            }
            
            if(instance == null)
            {
                Debug.LogError("Still no currency manager in scene");
            }
            return instance;
        }
    }

    public int Currency { get; private set; } = 0;

    public void ModifyCurrency(int amount)
    {
        Currency += amount;
        InterfaceManager.Instance.UpdateText();
    }
}

