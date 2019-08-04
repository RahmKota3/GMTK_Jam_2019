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
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //============KONIEC SINGLETONA=======================
    
    public enum Scene {
        BombLevel, HalfScreenVisible
    }
    public Scene currentScene;
    //nazwa enum scen ma być taka sama jak sceny do losowanie, trzeba dodać wszystkie enumy tu V
    public static List<Scene> TestoweSceny = new List<Scene>() { Scene.BombLevel, Scene.HalfScreenVisible };
    private bool[] visited = new bool[100];
    public int numberOfScenes = 3;
    public int visitedScenes = 0;

    public Scene RandomScene()
    {
        Debug.Log("GenerateScene");
        Scene nextScene;
        //losowanie sceny
        // Scene[] sceny = { Scene.Test1, Scene.Test2, Scene.Test3 };
        int randomIndex = 0;
        numberOfScenes = TestoweSceny.Count;
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
        else
        {
            for(int i = 0; i < numberOfScenes; i++)
            {
                visitedScenes = 0;
                visited[i] = false;
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
        QuirkManager.Instance.QuirkSetup();
    }


}
