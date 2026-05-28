using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class SaveData
    {
        public int CurrentLevelIndex = 0;
        
        public int LastLoadedLevelIndex = 0;

        public bool IsFirstLaunch = true;
        
        public float MusicVolume = 0.45f;
    }
    
    public class SaveManager
    {
        private const string SaveFileName = "savegame.json";
        private readonly string _savePath;
        
        public SaveData Data { get; private set; }

        public SaveManager()
        {
            _savePath = Path.Combine(Application.persistentDataPath, SaveFileName);
            Load();
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(Data, true);
            File.WriteAllText(_savePath, json);
            Debug.Log($"[SaveService] Saved to: {_savePath}");
        }

        public void Load()
        {
            if (File.Exists(_savePath))
            {
                try
                {
                    string json = File.ReadAllText(_savePath);
                    Data = JsonUtility.FromJson<SaveData>(json);
                    Debug.Log("[SaveService] Data loaded.");
                }
                catch (Exception e)
                {
                    Debug.LogError($"[SaveService] Failed to load save: {e.Message}");
                    CreateNewSave();
                }
            }
            else
            {
                CreateNewSave();
            }
            Data.LastLoadedLevelIndex = Data.CurrentLevelIndex;
        }

        private void CreateNewSave()
        {
            Debug.Log("[SaveService] Creating new save file.");
            Data = new SaveData();
            Save();
        }

        public void ResetSave()
        {
            Data = new SaveData();
            Save();
        }

        public bool DidTrainExpanded()
        {
            Debug.Log($"Текущий индекс {Data.CurrentLevelIndex}, последний загруженный - {Data.LastLoadedLevelIndex}");
            return Data.CurrentLevelIndex != Data.LastLoadedLevelIndex;
        }
    }
}