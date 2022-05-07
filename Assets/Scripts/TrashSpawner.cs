using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    //Laver et array for at kunne nemt tage ind de forskellige PreFabs
    [SerializeField] public GameObject[] trashPrefab;

    //Variabler som skal vises i inspector men ikke skal kaldes af andre scipts
    [SerializeField] float timeBetweenSpawn = 3f;
    [SerializeField] float fasterTime = 0.5f;
    [SerializeField] float minTrans;
    [SerializeField] float maxTrans;

    private void Start()
    {
        //Starter med at spawne.
        StartCoroutine(TrashSpawn());

    }

    IEnumerator TrashSpawn()
    {
        //Mens den er aktiv skal den spawne skrald.
        while (true)
        {
            //Den venter et antal sekunder
            yield return new WaitForSeconds(timeBetweenSpawn);

            //Lavet som en random range, så den kunne blive brugt i andre baner senere i spillet.
            var wanted = Random.Range(minTrans, maxTrans);
            //Sætter positionen af det skrald til det random stykke.
            var position = new Vector3(wanted, transform.position.y);

            //Spawner et random prefab fra vores array til vores position, uden at den bliver roteret.
            GameObject gameObject = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], position, Quaternion.identity);

            //Den bliver ved med at lave spawn tiden mindere, indtil den rammer 0.8 sekunder mellemrum.
            if (timeBetweenSpawn > 0.8f)
            {
                timeBetweenSpawn -= fasterTime;
            }
            
        }
    }
}
