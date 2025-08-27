using TMPro;
using UnityEngine;

public class MoveButton : MonoBehaviour
{

    [SerializeField] private TextMeshPro m_MoveName;
    [SerializeField] private TextMeshPro m_MoveType;

    private PokemonMove m_MoveToChoose;
  
   public void Initialize(PokemonMove p_Move)
    {
        m_MoveName.text = p_Move.MoveName;
        m_MoveType.text = p_Move.MoveType.ToString();
        m_MoveToChoose = p_Move;


    }

    public void OnClick()
    {
        
    }
}