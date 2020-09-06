using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGPSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEGPInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private IEnumerator SpawnAllEGPInWave (WaveConfig wavConfig)
   {
       for (int EGPCount = 0; EGPCount < wavConfig.GetNumberOfEnemies(); EGPCount ++)
       {
       Instantiate(
       wavConfig.GetEnemyPrefab(), 
       wavConfig.GetWaypoints()[0].transform.position, 
       Quaternion.identity);
       yield return new WaitForSeconds(wavConfig.GetTimeBetweenSpawns());
       }

       

   }
}
