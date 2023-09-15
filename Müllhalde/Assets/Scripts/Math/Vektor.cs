using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3 : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public Vector3()
    {
        this.x = 0.0f;
        this.y = 0.0f;
        this.z = 0.0f;
    }
    public Vector3(float _x, float _y, float _z)
    {
        this.x = _x;
        this.y = _y;
        this.z = _z;
    }

    public static Vector3 Plus(Vector3 _v1, Vector3 _v2)
    {
        return new Vector3(_v1.x + _v2.x, _v1.y + _v2.y, _v1.z + _v2.z);
    }
    public static UnityEngine.Vector3 Minus(UnityEngine.Vector3 _v1, UnityEngine.Vector3 _v2)
    {
        return new UnityEngine.Vector3(_v1.x - _v2.x, _v1.y - _v2.y, _v1.z - _v2.z);
    }
    public static Vector3 Mal(Vector3 _v1, float _skalar)
    {
        return new Vector3(_v1.x * _skalar, _v1.y * _skalar, _v1.z * _skalar);
    }
    public static float Distanz(Vector3 _v1, Vector3 _v2)
    {
        return (float)Math.Pow(((_v1.x - _v2.x) * (_v1.x - _v2.x)) + ((_v1.y - _v2.y) * (_v1.y - _v2.y)) + ((_v1.z - _v2.z) * (_v1.z - _v2.z)), 0.5);
    }
    public static float VektorLaenge(Vector3 _v1)
    {
        return (float)Math.Pow((_v1.x * _v1.x) + (_v1.y * _v1.y) + (_v1.z * _v1.z), 0.5);
    }
    public static float VektorQuadratLaenge(Vector3 _v1)
    {
        return (_v1.x * _v1.x) + (_v1.y * _v1.y) + (_v1.z * _v1.z);
    }
}

