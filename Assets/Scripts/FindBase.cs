using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[AddComponentMenu("Tools/AAA")]
public class FindBase : MonoBehaviour
{
    /// <summary>
    /// 查找一个矩阵下所有的矩阵
    /// </summary>
    /// <param name="tform"></param>
    /// <param name="alldd"></param>
    /// <returns></returns>
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

    private GameObject Getobj(string name)
    {
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
    private T getCompent<T>(string objName) where T : Object
    {
        T obj = default(T);
        GameObject b = Getobj(objName);
        if (b != null)
        {
            obj = b.GetComponent<T>();
        }
        return obj;
    }

    public Button GetButton(string objName) 
    {
        return getCompent<Button>(objName);
    }
    //public UIEvent GetUIEvent(string objName)
    //{
    //    return getCompent<UIEvent>(objName);
    //}
    public Text GetText(string objName)
    {
        return getCompent<Text>(objName);
    }
    public Image GetImage(string objName)
    {
        return getCompent<Image>(objName);
    }
    public InputField GetInputField(string objName)
    {
        return getCompent<InputField>(objName);
    }
    public RawImage GetRawImage(string objName)
    {
        return getCompent<RawImage>(objName);
    }
    public Slider GetSlider(string objName)
    {
        return getCompent<Slider>(objName);
    }
    public Toggle GetToggle(string objName)
    {
        return getCompent<Toggle>(objName);
    }

    public RectTransform GetRectTransform(string objName)
    {
        return getCompent<RectTransform>(objName);
    }

    public Scrollbar GetScrollbar(string objName)
    {
        return getCompent<Scrollbar>(objName);
    }

    public ScrollRect GetScrollView(string objName)
    {
        return getCompent<ScrollRect>(objName);
    }

    public Dropdown GetDropdown(string objName)
    {
        return getCompent<Dropdown>(objName);
    }
    public Camera GetCamera(string objName)
    {
        return getCompent<Camera>(objName);
    }
    public Light GetLight(string objName)
    {
        return getCompent<Light>(objName);
    }
    public AudioListener GetAudioListener(string objName)
    {
        return getCompent<AudioListener>(objName);
    }
    public Canvas GetCanvas(string objName)
    {
        return getCompent<Canvas>(objName);
    }
    public CanvasScaler GetCanvasScaler(string objName)
    {
        return getCompent<CanvasScaler>(objName);
    }
    public GraphicRaycaster GetGraphicRaycaster(string objName)
    {
        return getCompent<GraphicRaycaster>(objName);
    }
    public EventSystem GetEventSystem(string objName)
    {
        return getCompent<EventSystem>(objName);
    }

    public StandaloneInputModule GetStandaloneInputModule(string objName)
    {
        return getCompent<StandaloneInputModule>(objName);
    }

    public MeshFilter GetMeshFilter(string objName)
    {
        return getCompent<MeshFilter>(objName);
    }
    public MeshRenderer GetMeshRenderer(string objName)
    {
        return getCompent<MeshRenderer>(objName);
    }
    public BoxCollider GetBoxCollider(string objName)
    {
        return getCompent<BoxCollider>(objName);
    }
    public BoxCollider2D GetBoxCollider2D(string objName)
    {
        return getCompent<BoxCollider2D>(objName);
    }
    public Rigidbody GetRigidbody(string objName)
    {
        return getCompent<Rigidbody>(objName);
    }
    public AudioSource GetAudioSource(string objName)
    {
        return getCompent<AudioSource>(objName);
    }
    public ParticleSystem GetParticleSystem(string objName)
    {
        return getCompent<ParticleSystem>(objName);
    }
    public Animator GetAnimator(string objName)
    {
        return getCompent<Animator>(objName);
    }
}