using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;
    public GameObject objectPrefab;
    public GameObject numberLabel;
    public ClickRegister clickRegister;
    public float currentLevel;
    List<GameObject> spawnPoint = new List<GameObject>();
    private bool needLevel = false;
    public LineLogic lineLogic;
    private GameObject mainCanva;
    public GameObject buttonPrefab;
    public Button button;

    [SerializeField] private SoundSystem soundSystem;
    
    

    [System.Serializable]
    public class Level
    {
        public string[] level_data;
        public float[] xCoordinates;
        public float[] yCoordinates;
    }

    [System.Serializable]
    public class LevelList
    {
        public Level[] levels;

    }

    float ConvertToUnityX(float x)
    {
       
        return x;
    }

    float ConvertToUnityY(float y)
    {
       
        return 1000 - y;
    }


    public LevelList levelList = new LevelList();

    
    void Start()
    {
        currentLevel = PlayerPrefs.GetFloat("Level");
        mainCanva = GameObject.FindGameObjectWithTag("MainCanva");
        levelList = JsonUtility.FromJson<LevelList>(textJSON.text);

        for (int i = 0; i < levelList.levels.Length; i++)
        {
            
            levelList.levels[i].xCoordinates = new float[levelList.levels[i].level_data.Length / 2];
            levelList.levels[i].yCoordinates = new float[levelList.levels[i].level_data.Length / 2];

            for (int j = 0; j < levelList.levels[i].level_data.Length; j += 2)
            {
                
                levelList.levels[i].xCoordinates[j / 2] = float.Parse(levelList.levels[i].level_data[j]);
                levelList.levels[i].yCoordinates[j / 2] = float.Parse(levelList.levels[i].level_data[j + 1]);
            }
        }

        clickRegister.SetPointsCount(levelList.levels[(int)currentLevel].xCoordinates.Length);

        int scaleCoeff = 35;
        if (currentLevel == 0f)
        {
            scaleCoeff = 300;
        }
        if (currentLevel == 1f)
        {
            scaleCoeff = 200;
        }
        if (currentLevel == 2f)
        {
            scaleCoeff = 150;
        }
        if (currentLevel == 3f)
        {
            scaleCoeff = 75;
        }

        for (int i = 0; i < levelList.levels[(int)currentLevel].xCoordinates.Length; i++)
        {

            Vector3 spawnPosition = new Vector3(ConvertToUnityX(levelList.levels[(int)currentLevel].xCoordinates[i]), ConvertToUnityY(levelList.levels[(int)currentLevel].yCoordinates[i]), 0f);

            Vector3 desiredScale = new Vector3(scaleCoeff, scaleCoeff, scaleCoeff); // Example scale values
            GameObject spawnedPoint = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            spawnedPoint.transform.SetParent(mainCanva.transform);
            spawnPoint.Add(spawnedPoint);
            spawnPoint[spawnPoint.Count - 1].transform.localScale = desiredScale;
            spawnPoint[spawnPoint.Count - 1].GetComponent<PointLabel>().SetLabel(i + 1);



        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "SampleScene")
            {
                SceneManager.LoadScene("Menu");
            }
            
        }
        /*
        if (clickRegister.GetSize() == clickRegister.maxSize && lineLogic.canMoveOn)
        {
            //soundSystem.Finish.Play();

            if (currentLevel != levelList.levels.Length - 1)
            {
                StartCoroutine(ResetPoints());

                currentLevel += 1;
                needLevel = true;
                clickRegister.Refresh();
                clickRegister.SetPointsCount(levelList.levels[(int)currentLevel].xCoordinates.Length);
            }
            else
            {
                soundSystem.Finish.Play();
                StartCoroutine(ResetPoints());
                
            }
            
        }
        if(needLevel)
        {
            StartCoroutine(SetLevel());
            needLevel = false;

        }
    }
    IEnumerator ResetPoints()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < spawnPoint.Count; i++)
        {
            Destroy(spawnPoint[i]);
        }
    }
    IEnumerator SetLevel()
    {
        yield return new WaitForSeconds(2f);
        int scaleCoeff = 35;
        if (currentLevel == 0f)
        {
            scaleCoeff = 35;
        }
        if(currentLevel == 1f)
        {
            scaleCoeff = 200;
        }
        if(currentLevel == 2f)
        {
            scaleCoeff = 150;
        }
        if(currentLevel == 3f)
        {
            scaleCoeff = 75;
        }

        Debug.Log(scaleCoeff);
        for (int i = 0; i < levelList.levels[(int)currentLevel].xCoordinates.Length; i++)
        {

            Vector3 spawnPosition = new Vector3(ConvertToUnityX(levelList.levels[(int)currentLevel].xCoordinates[i]), ConvertToUnityY(levelList.levels[(int)currentLevel].yCoordinates[i]), 0f);



            // Instantiate object at calculated position
            
            Vector3 desiredScale = new Vector3(scaleCoeff, scaleCoeff, scaleCoeff); // Example scale values
            GameObject spawnedPoint = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            spawnedPoint.transform.SetParent(mainCanva.transform);
            spawnPoint.Add(spawnedPoint);
            spawnPoint[spawnPoint.Count - 1].transform.localScale = desiredScale;
            spawnPoint[spawnPoint.Count - 1].GetComponent<PointLabel>().SetLabel(i + 1);



        }
        needLevel = false;*/
    }

}
