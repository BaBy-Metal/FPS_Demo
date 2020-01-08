using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 查找组件
/// </summary>
public class FindComponent : MonoBehaviour
{
    public static Dictionary<int, T> FindTransforms<T>(Transform root, Dictionary<int, T> Chile = null)
    {
        if (Chile == null) { Chile = new Dictionary<int, T>(); }

        T d = root.GetComponent<T>();
        if (d != null)
        {
            Chile[root.GetInstanceID()] = d;
        }

        if (root.childCount == 0)
        {
            return Chile;
        }
        for (int i = 0; i < root.childCount; i++)
        {
            FindTransforms(root.GetChild(i), Chile);
        }
        return Chile;
    }

    /// <summary>
    /// 查找prefab 中 的物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private GameObject GetGameObject(string name)
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (var item in buttons)
        {
            string _name = item.name;
        }

        GameObject obj = null;
        Dictionary<int, Transform> finds = FindTransforms<Transform>(this.transform);
        foreach (int Iter in finds.Keys)
        {
            if (finds[Iter].name == name)
            {
                obj = finds[Iter].gameObject;
            }
        }
        return obj;
    }
    /// <summary>
    /// 获得 prefab 上面挂载的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objName"></param>
    /// <returns></returns>
    private T getComponent<T>(string objName) where T : Component
    {
        T Cmpent = null;
        GameObject b = GetGameObject(objName);
        if (b != null)
        {
            Cmpent = b.GetComponent<T>();

            if (Cmpent == null)
            {
                Cmpent = b.AddComponent<T>();
            }
        }
        return Cmpent;
    }
    /// <summary>
    /// 获取组件
    /// </summary>
    /// <param name="objName"></param>
    /// <param name="ComponentType"></param>
    /// <returns></returns>
    public Component GetComponent(string objName, string ComponentType)
    {
        if (ComponentType == "")
        {
            return getComponent<Component>(objName);
        }

        Component d = null;
        switch (ComponentType)
        {
            case "Transform": { d = getComponent<Transform>(objName); } break;
            case "Button": { d = getComponent<Button>(objName); } break;
            //case "UIEvent": { d = getComponent<UIEvent>(objName); } break;
            case "Text": { d = getComponent<Text>(objName); } break;
            case "Image": { d = getComponent<Image>(objName); } break;
            case "InputField": { d = getComponent<InputField>(objName); } break;
            case "RawImage": { d = getComponent<RawImage>(objName); } break;
            case "Slider": { d = getComponent<Slider>(objName); } break;
            case "Toggle": { d = getComponent<Toggle>(objName); } break;
            case "Scrollbar": { d = getComponent<Scrollbar>(objName); } break;
            case "ScrollRect": { d = getComponent<ScrollRect>(objName); } break;
            case "Dropdown": { d = getComponent<Dropdown>(objName); } break;
            case "Camera": { d = getComponent<Camera>(objName); } break;
            case "Light": { d = getComponent<Light>(objName); } break;
            case "AudioListener": { d = getComponent<AudioListener>(objName); } break;
            case "Canvas": { d = getComponent<Canvas>(objName); } break;
            case "CanvasScaler": { d = getComponent<CanvasScaler>(objName); } break;
            case "GraphicRaycaster": { d = getComponent<GraphicRaycaster>(objName); } break;
            case "EventSystem": { d = getComponent<EventSystem>(objName); } break;
            case "StandaloneInputModule": { d = getComponent<StandaloneInputModule>(objName); } break;
            case "MeshFilter": { d = getComponent<MeshFilter>(objName); } break;
            case "MeshRenderer": { d = getComponent<MeshRenderer>(objName); } break;
            case "BoxCollider": { d = getComponent<BoxCollider>(objName); } break;
            case "BoxCollider2D": { d = getComponent<BoxCollider2D>(objName); } break;
            case "Rigidbody": { d = getComponent<Rigidbody>(objName); } break;
            case "AudioSource": { d = getComponent<AudioSource>(objName); } break;
            case "ParticleSystem": { d = getComponent<ParticleSystem>(objName); } break;
            case "Animator": { d = getComponent<Animator>(objName); } break;
        }
        return d;
    }
}