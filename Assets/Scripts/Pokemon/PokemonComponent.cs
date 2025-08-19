using UnityEngine;

public class PokemonComponent : MonoBehaviour
{
    public PokemonInformation Information => m_PokemonInformation;
    PokemonInformation m_PokemonInformation;
    Animator m_Animator;

    public void Initialize(PokemonDefinition p_Definition)
    {
        m_PokemonInformation = new PokemonInformation(p_Definition);
        m_Animator = m_PokemonInformation.SpawnModel(transform).GetComponent<Animator>();
        name = m_PokemonInformation.Name;
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
        return m_PokemonInformation.Moves[Random.Range(0, m_PokemonInformation.Moves.Length)];
    }
}
