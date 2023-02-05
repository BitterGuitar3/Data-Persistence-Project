using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string name;
    public string highScoreName;
    public int bestScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(name);
    }

    class SaveData
    {
        public string name;
        public string highScoreName;
        public int bestScore;
    }

    public void SaveStats()
    {
        SaveData data = new SaveData();
        data.name = GameManager.instance.name;
        data.highScoreName = GameManager.instance.highScoreName;
        data.bestScore = GameManager.instance.bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("Stats Saved");
    }

    public void LoadStats()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameManager.instance.name = data.name;
            GameManager.instance.highScoreName = data.highScoreName;
            GameManager.instance.bestScore = data.bestScore;
            Debug.Log("Loaded Satst");
            Debug.Log(path);
        }

    }
}