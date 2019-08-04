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
        BombLevel, HalfScreenVisible, CrazyProjectile, MoveByShooting
    }
    public Scene currentScene;
    //nazwa enum scen ma być taka sama jak sceny do losowanie, trzeba dodać wszystkie enumy tu V
    public static List<Scene> TestoweSceny = new List<Scene>() { Scene.BombLevel, Scene.HalfScreenVisible, Scene.CrazyProjectile, Scene.MoveByShooting };
    public int numberOfScenes = 3;
    int previousScene = 999;
    public Scene RandomScene()
    {
        Scene nextScene;
        //losowanie sceny
        // Scene[] sceny = { Scene.Test1, Scene.Test2, Scene.Test3 };
        int randomIndex = 0;

            while (true)
        {
            randomIndex = Random.Range(0, numberOfScenes);
            if (randomIndex != previousScene)
            {
                previousScene = randomIndex;
                break;
            }
        }
        //zmienic size na coś normalnego xd
                
        
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
