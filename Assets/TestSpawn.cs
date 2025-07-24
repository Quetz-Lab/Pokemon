using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField] public PokemonDefinition pokemonDefinition;
    [SerializeField] public PokemonDefinition pokemonDefinition2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.SpawnPokemon(pokemonDefinition, transform.position);
        GameManager.SpawnPokemon(pokemonDefinition2, transform.position + Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
