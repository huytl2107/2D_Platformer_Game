using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class Sound 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Sound> sounds;

    public Dictionary<string, Queue<GameObject>> soundsDictionary;

    [System.Serializable]
    public class Music 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Music> musics;

    public Dictionary<string, Queue<GameObject>> musicsDictionary;
    
    void Start()
    {
        soundsDictionary = new Dictionary<string, Queue<GameObject>>();
        musicsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Sound pool in sounds) 
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for(int i=0 ; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                //Đảm bảo sound được thêm vào sound Manager không bị hủy khi load sceneS
                DontDestroyOnLoad(obj);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }    
            soundsDictionary.Add(pool.tag, objectsPool);
        }

        foreach(Music pool in musics) 
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for(int i=0 ; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                //Đảm bảo sound được thêm vào sound Manager không bị hủy khi load sceneS
                DontDestroyOnLoad(obj);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }    
            musicsDictionary.Add(pool.tag, objectsPool);
        }

    }

    public GameObject PlaySound(string tag)
    {
        if(!soundsDictionary.ContainsKey(tag))
        {
            Debug.Log("Key " + tag + " doesn't exist!!!");
            return null;
        }

        GameObject objToSpawn = soundsDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);

        soundsDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

    public GameObject PlayMusic(string tag)
    {
        if(!musicsDictionary.ContainsKey(tag))
        {
            Debug.Log("Key " + tag + " doesn't exist!!!");
            return null;
        }

        GameObject objToSpawn = musicsDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);

        musicsDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}
