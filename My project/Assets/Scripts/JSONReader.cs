using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;
    public GameObject objectPrefab;
    public GameObject numberLabel;
    public ClickRegister clickRegister;
    private int currentLevel = 1;

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
        // Center the coordinate space and invert the Y-coordinate
        return x - 500;
    }

    float ConvertToUnityY(float y)
    {
        // Invert the Y-coordinate
        return 1000 - y - 500;
    }

    public LevelList levelList = new LevelList();

    // Start is called before the first frame update
    void Start()
    {
        levelList = JsonUtility.FromJson<LevelList>(textJSON.text);

        for (int i = 0; i < levelList.levels.Length; i++)
        {
            // Initialize xCoordinates and yCoordinates arrays with half the length of level_data array
            levelList.levels[i].xCoordinates = new float[levelList.levels[i].level_data.Length / 2];
            levelList.levels[i].yCoordinates = new float[levelList.levels[i].level_data.Length / 2];

            for (int j = 0; j < levelList.levels[i].level_data.Length; j += 2)
            {
                // Parse and assign x and y coordinates
                levelList.levels[i].xCoordinates[j / 2] = float.Parse(levelList.levels[i].level_data[j]);
                levelList.levels[i].yCoordinates[j / 2] = float.Parse(levelList.levels[i].level_data[j + 1]);
            }
        }

        clickRegister.SetPointsCount(levelList.levels[currentLevel].xCoordinates.Length);

            for (int i = 0; i < levelList.levels[currentLevel].xCoordinates.Length; i++)
            {
                
                Vector3 spawnPosition = new Vector3(ConvertToUnityX(levelList.levels[currentLevel].xCoordinates[i]), ConvertToUnityY(levelList.levels[currentLevel].yCoordinates[i])); 
                

                // Instantiate object at calculated position
                GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
                newObject.GetComponent<PointLabel>().SetLabel(i + 1);
               

               
            }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
