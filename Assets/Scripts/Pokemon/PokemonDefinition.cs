using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonDefinition", menuName = "Pokemon/Definition")]
public class PokemonDefinition : ScriptableObject
{
    public string PokemonName => m_PokemonName;
    public string Description => m_Description;
    public GameObject Model => m_Model;

    public Sprite Sprite => m_Sprite;
    public int Health => m_Health;
    public int Attack => m_Attack;
    public int SpecialAttack => m_SpecialAttack;
    public int Defense => m_Defense;
    public int SepcialDefense => m_SpecialDefense;
    public int Speed => m_Speed;
    
    public PokemonTypes.TypeList MainType => m_MainType;
    public PokemonTypes.TypeList SecondaryType => m_SecondaryType;
    public int EvolutionLevel => m_EvolutionLevel;
    public PokemonDefinition Evolution => m_Evolution;
    public PokemonMove[] Moves => m_Moves;

    [Header("General:")]
    [SerializeField]private string m_PokemonName;
    [SerializeField, TextArea] private string m_Description;
    [SerializeField] private GameObject m_Model;
    [SerializeField] private Sprite m_Sprite;

    [Header("Stats:")]
    [SerializeField, Range(0,100)]private int m_Health;
    [SerializeField, Range(0,100)]private int m_Attack;
    [SerializeField, Range(0,100)]private int m_SpecialAttack;
    [SerializeField, Range(0,100)]private int m_SpecialDefense;
    [SerializeField, Range(0,100)] private int m_Defense;
    [SerializeField, Range(0,100)]private int m_Speed;

    [SerializeField]private PokemonMove[] m_Moves;

    [Header("Types:")]
    [SerializeField] private PokemonTypes.TypeList m_MainType;
    [SerializeField] private PokemonTypes.TypeList m_SecondaryType;

    [Header("Evolution:")]
    [SerializeField] private int m_EvolutionLevel;
    [SerializeField] private PokemonDefinition m_Evolution;

    private void OnValidate()
    {
        {
            
        }
        if (m_Moves.Length > 4)
        {
            Debug.LogWarning("A Pokemon can only have up to 4 movements");
            System.Array.Resize(ref m_Moves, 4);
        }
    }

    private void LearnMove()
    {
        // Logic to learn a new move
        if (m_Moves.Length >= 4)
        {
            Debug.LogWarning($"{m_PokemonName} already knows 4 moves. Cannot learn more.");
            return;
        }
        // Add logic to add a new move to the m_Moves array
        for (int i = 0; i < m_Moves.Length; i++)
        {
            if (m_Moves[i] == null)
            {
                // Assume newMove is a valid PokemonMove object
                // m_Moves[i] = newMove;
                break;
            }
        }
    }

}
