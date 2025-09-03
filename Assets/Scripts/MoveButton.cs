using TMPro;
using UnityEngine;

public class MoveButton : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI m_MoveName, m_Type, m_Power;

    private PokemonMove m_MoveToChoose;
  
   public void Initialize(PokemonMove p_Move)
   {
        m_MoveToChoose = p_Move;
        m_MoveName.text = m_MoveToChoose.name;
        m_Power.text = $"Power: { m_MoveToChoose.Power.ToString()}";
        m_Type.text = $"Type: { m_MoveToChoose.MoveType.ToString()}";


   }

    public void InformCombatManager()
    {
        if (CombatManager.Instance == null) return;
        CombatManager.SetPlayerMove(m_MoveToChoose);
    }
}