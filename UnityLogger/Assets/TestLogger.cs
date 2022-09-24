using Sirenix.OdinInspector;
using UnityEngine;
using Vecerdi.UnityLogger;

public class TestLogger : MonoBehaviour {
    [Button]
    private void Start() {
        Log.Trace("Hello World");
        Log.Debug("Hello World");
        Log.Info("Hello World");
        Log.Warn("Hello World");
        Log.Error("Hello World");
        Log.Fatal("Hello World");
        Log.Exception(new System.Exception("Hello World"));
    }
}