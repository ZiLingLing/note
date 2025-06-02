using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public interface IClone<T>
{
    T Clone();
}


//ͨ���������
[Serializable]
public class BaseClone<T> : MonoBehaviour , IClone<T> where T : class , new()
{
    //ǳ����
    public virtual T ShallowClone()
    {
        return (T)this.Clone();
    }

    //���
    public virtual T DeepClone()
    {
        try
        {
            using (Stream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (T)formatter.Deserialize(memoryStream);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("��¡�쳣:" + ex.ToString());
        }
        return default(T);
    }

    public T Clone()
    {
        return this.MemberwiseClone() as T;//�\����
    }
}
