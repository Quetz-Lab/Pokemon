using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewCombatUI : MonoBehaviour
{
    [SerializeField]private GameObject m_ButtonPrefab;
    [SerializeField] private Transform m_ButtonParent;
    [SerializeField] private TextMeshProUGUI m_TextBox;
    [SerializeField] private TextMeshProUGUI m_PlayerPokemon;
    [SerializeField] private Slider m_PlayerHealthTxt;
    [SerializeField] private Slider m_EnemyHealthTxt;
    [SerializeField] private GameObject m_WinScreen;
    [SerializeField] private GameObject m_LoseScreen;
    public void Initialized(PokemonInformation pokemonInformation)
    {
        if (pokemonInformation.Moves == null || pokemonInformation.Moves.Length == 0)
        {
            Debug.LogError("This pokemon Has no moves");
            return;
        }
        foreach (var move in pokemonInformation.Moves)
        {
            MoveButton button = Instantiate(m_ButtonPrefab, m_ButtonParent).GetComponent<MoveButton>();
            button.Initialize(move);
        }
       
    }

    public void SetTextBox(string message)
    {
        m_TextBox.text = message;
        //m_PlayerPokemon.text = "Bianca";
    }

    public void UpdateHealth(PokemonInformation p_playerInfo, PokemonInformation p_enemyInfo)
    {
        m_PlayerHealthTxt.maxValue = p_playerInfo.MaxHealth;
        m_PlayerHealthTxt.value = p_playerInfo.CurrentHealth;
        m_EnemyHealthTxt.maxValue = p_enemyInfo.MaxHealth;
        m_EnemyHealthTxt.value = p_enemyInfo.CurrentHealth;
    }
    public void ShowWinScreen()
    {
        m_WinScreen.SetActive(true);
    }
    public void ShowLoseScreen()
    {
        m_LoseScreen.SetActive(true);
    }

    }
