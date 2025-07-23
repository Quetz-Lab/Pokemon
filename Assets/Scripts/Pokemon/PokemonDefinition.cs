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

    [Header("General:")]
    [SerializeField]private string m_PokemonName;
    [SerializeField] private string m_Description;
    [SerializeField] private GameObject m_Model;
    [SerializeField] private Sprite m_Sprite;

    [Header("Stats:")]
    [SerializeField]private int m_Health;
    [SerializeField]private int m_Attack;
    [SerializeField]private int m_SpecialAttack;
    [SerializeField]private int m_SpecialDefense;
    [SerializeField] private int m_Defense;
    [SerializeField]private int m_Speed;

    [Header("Types:")]
    [SerializeField] private PokemonTypes.TypeList m_MainType;
    [SerializeField] private PokemonTypes.TypeList m_SecondaryType;

    [Header("Evolution:")]
    [SerializeField] private int m_EvolutionLevel;
    [SerializeField] private PokemonDefinition m_Evolution;
}
