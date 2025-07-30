using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    [SerializeField]  float GlobalxpRate = 1.0f;
    [SerializeField] private GameObject CombatArenaPrefab;
<<<<<<< Updated upstream
=======
    [SerializeField] private GameObject PokemonPrefab;
    [SerializeField] private PokemonDefinition pkmn1;
    [SerializeField] private PokemonDefinition pkmn2;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
}