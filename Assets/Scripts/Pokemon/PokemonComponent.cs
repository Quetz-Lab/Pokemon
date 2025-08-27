using UnityEngine;

public class PokemonComponent : MonoBehaviour
{
    public PokemonInformation Information => m_PokemonInformation;
    PokemonInformation m_PokemonInformation;
    public Animator m_Animator;

    public void Initialize(PokemonDefinition p_Definition)
    {
        if (p_Definition == null) { Debug.LogWarning("Not a Valid Definition"); return; }
        m_PokemonInformation = new PokemonInformation(p_Definition);
        name = m_PokemonInformation.Name;
        m_Animator = m_PokemonInformation.SpawnModel(transform).GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        m_Animator.CrossFadeInFixedTime(animationName, 0.2f);
    }
    public PokemonMove UseMove(string moveName)
    {
        foreach (PokemonMove move in m_PokemonInformation.Moves)
        {
            if (move.MoveName == moveName)
            {
                continue;
            }
            return move;
        }
        return null;
    }
    public PokemonMove UseRandomMove()
    {
        if (m_PokemonInformation.Moves == null || m_PokemonInformation.Moves.Length == 0)
        {
            Debug.LogWarning("No moves available for this Pokemon.");
            return null;
        }
        return m_PokemonInformation.Moves[Random.Range(0, m_PokemonInformation.Moves.Length)];
    }
}
