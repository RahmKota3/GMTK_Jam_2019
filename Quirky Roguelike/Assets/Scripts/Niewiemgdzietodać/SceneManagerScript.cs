using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //============KONIEC SINGLETONA=======================
    
    public enum Scene {
        StartingScene,
        TestScene,
        Test1,
        Test2,
        Test3,
    }
    public Scene currentScene;
    public List<Scene> TestoweSceny = new List<Scene>() { Scene.Test1, Scene.Test2, Scene.Test3 };
    private bool[] visited = new bool[100];
    public int numberOfScenes = 3;
    public int visitedScenes = 0;

    public Scene RandomScene()
    {
        Debug.Log("GenerateScene");
        Scene nextScene;
        //losowanie sceny
        // Scene[] sceny = { Scene.Test1, Scene.Test2, Scene.Test3 };
        int randomIndex= 0;
        if (visitedScenes != numberOfScenes)
        {
            while (true)
            {
                randomIndex = Random.Range(0, numberOfScenes); //zmienic size na coś normalnego xd
                if (visited[randomIndex] == false)
                {
                    visited[randomIndex] = true;
                    visitedScenes++;
                    break;
                }

            }
        }
        Debug.Log(TestoweSceny[randomIndex]);
        nextScene = TestoweSceny[randomIndex];

        currentScene = nextScene;
        return nextScene;
    }

    public void Load(Scene scene)
    {
        Debug.Log("Load Scene");
        SceneManager.LoadScene(scene.ToString());
    }


}
