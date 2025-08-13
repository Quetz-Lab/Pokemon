using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    [SerializeField]  float GlobalxpRate = 1.0f;
    [SerializeField] private GameObject CombatArenaPrefab;
    [SerializeField] private GameObject PokemonPrefab;
    [SerializeField] private PokemonDefinition[] m_pkmToSpawn;
    [SerializeField] private PokemonDefinition pkmn1;
    [SerializeField] private PokemonDefinition pkmn2;
    
    public static GameManager GetInstance()
    {
        if (m_instance == null) { return m_instance; }
        m_instance = FindAnyObjectByType<GameManager>();
        if (m_instance != null) { return m_instance; }
        GameObject gameManagerObject = new GameObject("Game Manager");
        m_instance = gameManagerObject.AddComponent<GameManager>();
        return m_instance;
    }
    void Start()
    {
        m_instance = this;
        DontDestroyOnLoad(gameObject);
        SpawnPokemon(pkmn1, new Vector3(0, 0, 0));
        SpawnPokemon(pkmn2, new Vector3(2, 0, 0));
    }

    public static void StartCombat()
    {
        SceneManager.CreateScene("CombatArena", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        Scene combatArenaScene = SceneManager.GetSceneByName("CombatArena");
        if (combatArenaScene.isLoaded)
        {
            SceneManager.SetActiveScene(combatArenaScene);
            GameObject combatArena = Instantiate(GetInstance().CombatArenaPrefab);
            combatArena.transform.position = Vector3.zero;
        }
        else
        {
            Debug.LogError("Combat Arena scene could not be loaded");
        }
    }
    public static void SpawnPokemon (PokemonDefinition p_Pokemon, Vector3 p_Position)
    {
        PokemonComponent pokemonComponent = Instantiate(GetInstance().PokemonPrefab, p_Position, Quaternion.identity).GetComponent<PokemonComponent>();

        pokemonComponent.Initialize(p_Pokemon);
    }

    private static IEnumerator LoadCombatSceneAndInitialize(PokemonDefinition p_Poke1, PokemonDefinition p_Poke2)
    {
        AsyncOperation t_AsyncLoad = SceneManager.LoadSceneAsync("CombatScene");
        while (!t_AsyncLoad.isDone) { yield return null; }
        Instantiate(ForestArena);
        PokemonComponent t_Pokemon1 = NewPokemon.GetComponent<PokemonComponent>();
        t_Pokemon1.Initialize(p_Poke1);
        PokemonComponent t_Pokemon2 = NewPokemon.GetComponent<PokemonComponent>();
        t_Pokemon2.Initialize(p_Poke2);
    }
    public static GameObject NewPokemon => Instantiate(Instance.PokemonPrefab);
    public static void StartCombatWithRandomPokemon(PokemonDefinition p_Pokemon1)
    {
        PokemonDefinition p_Pokemon2 = m_instance.GetRandomPokemon();
        Instance.StartCorutine(LoadCombatSceneAndInitialize(p_Pokemon1,p_Pokemon2));
    }
}

