using UnityEngine;

public class TallGrass : MonoBehaviour
{
    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0f,360f), 0);
        transform.localScale = Vector3.one * Random.Range(0.9f, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player p_MainCharacter)) {return;}
        //WaitForSeconds(3.0f);
       

        if (Random.value < 1f) p_MainCharacter.GetAmbushed();
    }
}
