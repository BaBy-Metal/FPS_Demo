using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[AddComponentMenu("Tools/BBB")]
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
        string type = ComponentType.ToLower();
        if (type == "")
        {
            return getComponent<Component>(objName);
        }

        Component d = null;
        switch (ComponentType)
        {
            case "transform": { d = getComponent<Transform>(objName); } break;
            case "button": { d = getComponent<Button>(objName); } break;
            //case "UIEvent": { d = getComponent<UIEvent>(objName); } break;
            case "text": { d = getComponent<Text>(objName); } break;
            case "image": { d = getComponent<Image>(objName); } break;
            case "inputfield": { d = getComponent<InputField>(objName); } break;
            case "rawimage": { d = getComponent<RawImage>(objName); } break;
            case "slider": { d = getComponent<Slider>(objName); } break;
            case "toggle": { d = getComponent<Toggle>(objName); } break;
            case "scrollbar": { d = getComponent<Scrollbar>(objName); } break;
            case "scrollrect": { d = getComponent<ScrollRect>(objName); } break;
            case "dropdown": { d = getComponent<Dropdown>(objName); } break;
            case "camera": { d = getComponent<Camera>(objName); } break;
            case "light": { d = getComponent<Light>(objName); } break;
            case "audiolistener": { d = getComponent<AudioListener>(objName); } break;
            case "canvas": { d = getComponent<Canvas>(objName); } break;
            case "canvasscaler": { d = getComponent<CanvasScaler>(objName); } break;
            case "graphiceaycaster": { d = getComponent<GraphicRaycaster>(objName); } break;
            case "eventSystem": { d = getComponent<EventSystem>(objName); } break;
            case "standaloneinputmodule": { d = getComponent<StandaloneInputModule>(objName); } break;
            case "meshfilter": { d = getComponent<MeshFilter>(objName); } break;
            case "meshrenderer": { d = getComponent<MeshRenderer>(objName); } break;
            case "boxcollider": { d = getComponent<BoxCollider>(objName); } break;
            case "boxcollider2d": { d = getComponent<BoxCollider2D>(objName); } break;
            case "rigidbody": { d = getComponent<Rigidbody>(objName); } break;
            case "audiosource": { d = getComponent<AudioSource>(objName); } break;
            case "particlesystem": { d = getComponent<ParticleSystem>(objName); } break;
            case "animator": { d = getComponent<Animator>(objName); } break;
        }
        return d;
    }
}