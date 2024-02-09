using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LineLogic : MonoBehaviour
{
    public Sprite spriteToAssign;
    private List<LineRenderer> lineList;
    public GameObject linePrefab;
    public float animationDuration = 0.1f; 
    private Queue<Vector3> pointsQueue = new Queue<Vector3>();
    private bool isDrawing = false;
    private int count;
    public ClickRegister clickRegister;
    private Vector3 firstPoint;
    private Vector3 endPoint;
    public bool ending = false;
    public bool canMoveOn = false;
    public GameObject nextLevelCanva;
    public GameObject levelSelectionCanva;
    [SerializeField] private SoundSystem soundSystem;
    public JSONReader reader;

    void Start()
    {
        
        lineList = new List<LineRenderer>();
        count = 0;
        
    }

    void Update()
    {
        if((lineList.Count + 1) == clickRegister.maxSize)
        {
           
            //soundSystem.Finish.volume = PlayerPrefs.GetFloat("SoundVolume");
            soundSystem.Finish.Play();
            /*if (reader.currentLevel != reader.levelList.levels.Length - 1)
            {
                StartCoroutine(SetNextLevelCanva());
            }
            else
            {
                StartCoroutine(CloseGame());
                
            }*/
            StartCoroutine(OpenLevelSelection());
           
        }
        if (pointsQueue.Count >= 2 && !isDrawing)
        {
            Vector3 startPoint = pointsQueue.Dequeue();
            Vector3 endPoint = pointsQueue.Peek();
            LineRenderer newLine = Instantiate(linePrefab).GetComponent<LineRenderer>();
            lineList.Add(newLine);
            newLine.positionCount = 2;
            StartCoroutine(DrawLineSmoothly(startPoint, endPoint, animationDuration, newLine));
            isDrawing = true;
            canMoveOn = false;
        }
        if(count == clickRegister.maxSize && !isDrawing && (lineList.Count + 1) == clickRegister.maxSize)
        {
            
            ending = true;
            
        }
        if(ending)
        {
            
            count++;
            Vector3 startPoint = endPoint;
            Vector3 endPoint1 = firstPoint;
            pointsQueue.Dequeue();
            LineRenderer newLine = Instantiate(linePrefab).GetComponent<LineRenderer>();
            lineList.Add(newLine);
            newLine.positionCount = 2;
            ending = false;
            StartCoroutine(DrawLineSmoothly(startPoint, endPoint1, animationDuration, newLine));

            StartCoroutine(ResetLines());
        }    
    }
    IEnumerator OpenLevelSelection()
    {
        yield return new WaitForSeconds(3.25f);
        
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetFloat("Selection", 1);

    }
    IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(3f);
        nextLevelCanva.SetActive(true);
        nextLevelCanva.GetComponent<NextLevelLogic>().SetupFinish();

    }
    IEnumerator SetNextLevelCanva()
    {
        yield return new WaitForSeconds(3f);
        nextLevelCanva.SetActive(true);

    }
    IEnumerator DrawLineSmoothly(Vector3 startPoint, Vector3 endPoint, float duration, LineRenderer newLine)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            float t = elapsedTime / 0.5f;
            Vector3 currentPoint = Vector3.Lerp(startPoint, endPoint, t);
            newLine.SetPosition(0, startPoint);
            newLine.SetPosition(1, currentPoint);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        newLine.SetPosition(1, endPoint);
        isDrawing = false;
    }
    IEnumerator ResetLines()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < lineList.Count; i++)
        {
            Destroy(lineList[i]);

        }
        this.lineList = new List<LineRenderer>();
        count = 0;
        canMoveOn = true;
        firstPoint = Vector3.zero;
        endPoint = Vector3.zero;
        
    }
    public void UpdatePoints(Vector3 position)
    {
        if(count == 0)
        {
            firstPoint = position;
        }
        if(count + 1 == clickRegister.maxSize)
        {
            endPoint = position;
        }
        else
        {
            endPoint = Vector3.zero;
        }

        count++;
        pointsQueue.Enqueue(position);
    }
}
