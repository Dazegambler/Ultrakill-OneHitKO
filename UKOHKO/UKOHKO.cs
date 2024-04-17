namespace UKOHKO;

using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

[BepInPlugin("UKOHKO","UKOHKO","2.0")]
public class Plugin:BaseUnityPlugin
{
    ConfigEntry<KeyCode> ohkokey;

    ConfigEntry<bool> ohkostart;

    NewMovement Player;

    bool ohko = false;

    void Start(){
        Debug.Log("UKOHKO Loaded");
        ohkokey = Config.Bind("Binds","OHKO toggle", KeyCode.O, "Key to toggle One hit ko");
        ohkostart = Config.Bind("Misc","Start with OHKO enabled",false,"");
        ohko = ohkostart.Value;
    }

    void Update(){
        if(Input.GetKeyDown(ohkokey.Value)){
            ohko = !ohko;
            Debug.Log("ohko:"+ohko);
        }
        if(ohko){
            if(!Player){
                GetPlayer().hp = Mathf.Clamp(Player.hp,0,1);
                return;
            }
            Player.hp = Mathf.Clamp(Player.hp,0,1);
        }       
    }

    NewMovement GetPlayer(){
        Player = NewMovement.Instance;
        return Player;
    }
}
