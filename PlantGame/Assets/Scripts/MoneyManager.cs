using TMPro;
using UnityEngine;

/// <summary>
/// Affichage et gestion de l'argent total du joueur
/// </summary>

public class MoneyManager : MonoBehaviour
{
    public float _money;
    public static MoneyManager Instance;
    [SerializeField]
    private TextMeshProUGUI _moneyUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool Depense(float depense)
    {
        if(_money >= depense)
        {
            _money -= depense;
            return true;
        }
        return false;
    }

    public void Sell(float receipt)
    {
        _money += receipt;
    }

    void Update()
    {
        _moneyUI.text = _money.ToString();
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
}
