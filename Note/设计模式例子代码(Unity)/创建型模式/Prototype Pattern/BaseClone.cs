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


//通用深拷贝基类
[Serializable]
public class BaseClone<T> : MonoBehaviour , IClone<T> where T : class , new()
{
    //浅拷贝
    public virtual T ShallowClone()
    {
        return (T)this.Clone();
    }

    //深拷贝
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
            Debug.LogError("克隆异常:" + ex.ToString());
        }
        return default(T);
    }

    public T Clone()
    {
        return this.MemberwiseClone() as T;//淺拷贝
    }
}
