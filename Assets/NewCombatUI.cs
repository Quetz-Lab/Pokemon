using System.Linq;
using TMPro;
using UnityEngine;

public class NewCombatUI : MonoBehaviour
{
    [SerializeField]private GameObject m_ButtonPrefab;
    [SerializeField] private Transform m_ButtonParent;
    [SerializeField] private TextMeshProUGUI m_TextBox;
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
    }
}
