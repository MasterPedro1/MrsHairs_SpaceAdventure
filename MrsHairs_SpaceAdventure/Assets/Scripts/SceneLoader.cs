using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [ContextMenu("Load Scene")]
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
