using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] trashPrefab;

    [SerializeField] float timeBetweenSpawn = 3f;

    [SerializeField] float fasterTime = 0.5f;

    [SerializeField] float minTrans;

    [SerializeField] float maxTrans;

    private void Start()
    {

        StartCoroutine(TrashSpawn());

    }

    void Update()
    {


        //Lav om til at den starter når man kommer ind fra start skærmen og ellers pauser når man går ind på pause menu
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(TrashSpawn());
        }
    }

    IEnumerator TrashSpawn()
    {
        while (true)
        {
        yield return new WaitForSeconds(timeBetweenSpawn);

        var wanted = Random.Range(minTrans, maxTrans);
        var position = new Vector3(wanted, transform.position.y);
        GameObject gameObject = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], position, Quaternion.identity);


            if (timeBetweenSpawn > 0.8f)
            {
                timeBetweenSpawn -= fasterTime;
            }
            
        }
    }
}
