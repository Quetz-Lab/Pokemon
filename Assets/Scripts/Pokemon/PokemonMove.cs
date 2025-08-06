using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Pokemon/PokemonMove")]
public class PokemonMove : ScriptableObject
{
    #region Getters
    public string MoveName => m_MoveName;
    public string MoveDescription => m_MoveDescription;
    public int Power => m_Power;
    public int PowerPoints => m_PowerPoints;
    public int Accuracy => m_Accuracy;
    public bool IsSpecial => m_IsSpecial;
    public PokemonTypes.TypeList MoveType => m_MoveType;
    public string AnimationName => m_AnimationName;
    public Sprite Icon => m_Icon;
    public AudioClip SoundEffect => m_SoundEffect;
    public GameObject Effect => m_Effect;
    #endregion

    [Header("General Information")]
    [SerializeField] private string m_MoveName;
    [SerializeField, TextArea] private string m_MoveDescription;

    [Header("Stats")]
    [SerializeField] private int m_Power;
    [SerializeField] private int m_PowerPoints;
    [SerializeField, Range(0,100)] private int m_Accuracy;
    [SerializeField] private bool m_IsSpecial;
    [SerializeField] private PokemonTypes.TypeList m_MoveType;

    [Header("Visual Effects")]
    [SerializeField] private string m_AnimationName;
    [SerializeField] private Sprite m_Icon;
    [SerializeField] private AudioClip m_SoundEffect;
    [SerializeField] private GameObject m_Effect;

}
