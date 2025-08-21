using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameObject newCombatArena => Instantiate(GetInstance().CombatArenaPrefab);
    //[SerializeField] private GameObject m_CombatArenaPrefab;
    public static GameManager Instance => GetInstance();
    private static GameManager m_instance;
    [SerializeField] float GlobalxpRate = 1.0f;
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
    void Awake()
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
    public static PokemonComponent SpawnPokemon(PokemonDefinition p_Pokemon, Vector3 p_Position)
    {
        PokemonComponent pokemonComponent = Instantiate(GetInstance().PokemonPrefab, p_Position, Quaternion.identity).GetComponent<PokemonComponent>();

        pokemonComponent.Initialize(p_Pokemon);

        return pokemonComponent;
    }

    private static IEnumerator LoadCombatSceneAndInitialize(PokemonDefinition p_Poke1, PokemonDefinition p_Poke2)
    {
        AsyncOperation t_AsyncLoad = SceneManager.LoadSceneAsync("ForestArena");
        while (!t_AsyncLoad.isDone) { yield return null; }
        Instantiate(Instance.CombatArenaPrefab);
        PokemonComponent t_Pokemon1 = SpawnPokemon(p_Poke1, Vector3.zero);
        PokemonComponent t_Pokemon2 = SpawnPokemon(p_Poke2, Vector3.zero*-1);
        
    }
    public static void StartCombatWithRandomPokemon(PokemonDefinition p_Pokemon1)
    {
        PokemonDefinition p_Pokemon2 = m_instance.GetRandomPokemon();
        Instance.StartCoroutine(LoadCombatSceneAndInitialize(p_Pokemon1, p_Pokemon2));
    }
    public PokemonDefinition GetRandomPokemon()
    {
        if (m_pkmToSpawn == null) Debug.LogError("Not Intitialized Pokemons");
        if (m_pkmToSpawn.Length == 0) { Debug.LogError("No Pokemon to spawn"); return null; }
        int randomIndex = Random.Range(0, m_pkmToSpawn.Length);
        return m_pkmToSpawn[randomIndex];
    }

}

