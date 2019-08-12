using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore(int[] score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;
        }
        else
        {
            int[] info = new int[5];
            info[0] = 0;
            info[1] = 0;
            info[2] = 0;
            info[3] = 0;
            info[4] = 0;
            SaveScore(info);
            return LoadScore();
        }
    }

    public static void SaveHealth(int health)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/health.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        HealthData data = new HealthData(health);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static HealthData LoadHealth()
    {
        string path = Application.persistentDataPath + "/health.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HealthData data = formatter.Deserialize(stream) as HealthData;
            stream.Close();

            return data;
        }
        else
        {
            int info = 3;
            SaveHealth(info);
            return LoadHealth();
        }
    }

    public static void SaveCoins(int coins)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cooins.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        CoinsData data = new CoinsData(coins);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CoinsData LoadCoins()
    {
        string path = Application.persistentDataPath + "/cooins.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CoinsData data = formatter.Deserialize(stream) as CoinsData;
            stream.Close();

            return data;
        }
        else
        {
            int info = 0;
            SaveCoins(info);
            return LoadCoins(); 
        }
    }

    public static void Savetut(int tut)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tut.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SeenTutorialData data = new SeenTutorialData(tut);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SeenTutorialData Loadtut()
    {
        string path = Application.persistentDataPath + "/tut.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SeenTutorialData data = formatter.Deserialize(stream) as SeenTutorialData;
            stream.Close();

            return data;
        }
        else
        {
            int info = 0;
            Savetut(info);
            return Loadtut();
        }
    }

    public static void SaveMultiplier(int multiplier)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/multiplier1.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        MultiplierData data = new MultiplierData(multiplier);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MultiplierData LoadMultiplier()
    {
        string path = Application.persistentDataPath + "/multiplier1.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MultiplierData data = formatter.Deserialize(stream) as MultiplierData;
            stream.Close();

            return data;
        }
        else
        {
            int info = 1;
            SaveMultiplier(info);
            return LoadMultiplier();
        }
    }

    public static void SaveScoreMultiplier(int scoreMultiplier)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scoreMultiplier1.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreMultiplierData data = new ScoreMultiplierData(scoreMultiplier);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreMultiplierData LoadScoreMultiplier()
    {
        string path = Application.persistentDataPath + "/scoreMultiplier1.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreMultiplierData data = formatter.Deserialize(stream) as ScoreMultiplierData;
            stream.Close();

            return data;
        }
        else
        {
            int info = 1;
            SaveScoreMultiplier(info);
            return LoadScoreMultiplier();
        }
    }
}
