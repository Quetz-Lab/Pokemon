using UnityEngine;

public class PokemonComponent : MonoBehaviour
{
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
}
