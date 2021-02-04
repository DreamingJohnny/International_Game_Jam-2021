using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Properties")]
    public int startingAmount;

    void Start()
    {
        CurrencyManager.Instance.ModifyCurrency(startingAmount);
    }
}
