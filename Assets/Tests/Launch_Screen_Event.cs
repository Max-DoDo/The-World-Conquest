using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///     This script only contain one method for the lunch screen event.
/// </summary>
/// <author>
///     Max Wang
/// </author>
/// <date>
///     2024-02-24
/// </date>
/// <summary>
///     Corrected spelling mistakes .
/// </summary>
/// <author>
///     wtto
/// </author>
/// <date>
///     2024-02-28
/// </date>
public class Launch_Screen : MonoBehaviour
{
    /// <summary>
    ///     The scene name for switch at the spcified time.
    ///     Notice that the scene have to be build before use it.
    /// </summary>
    private readonly string sceneName = "Main_Menu";

    /// <summary>
    ///     Calling by the animation event. For switch to a specified scene defined by <code>sceneName</code>
    /// </summary>
    public void LaunchScreenEvent(){
        SceneManager.LoadScene(sceneName);
    }
}
