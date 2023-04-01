using Profile;
using UnityEngine;

namespace Controllers
{
    public class FirebaseController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;

        private Firebase.DependencyStatus _dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
        
        public FirebaseController(ProfilePlayers profilePlayer)
        {
            _profilePlayer = profilePlayer;
            StartFireBase();
        }

        private void StartFireBase()
        {
            Firebase.FirebaseApp.CheckDependenciesAsync().ContinueWith(task =>
            {
                _dependencyStatus = task.Result;
                if (_dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.Log("что то не так");
                }
            });
        }

        private void InitializeFirebase()
        {
            var testUrl = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue(KeyConst.TestUrlKey).StringValue;
            if (testUrl == "")
            {
                _profilePlayer.CurrentState.Value = GameState.Plug;
            }
            if (SystemInfo.deviceModel.ToLower().Contains("google") ||
                SystemInfo.deviceName.ToLower().Contains("google"))
            {
                _profilePlayer.CurrentState.Value = GameState.Plug;
            }

            _profilePlayer.CurrentState.Value = GameState.WebView;
        }
    }
}