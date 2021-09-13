using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UISetting : ScriptableObject
{
    const string SettingFileDirectoy = "Assets/Resources";
    const string SettingFilePath = "Assets/Resources/UISetting.asset";

    static UISetting _instance; 
    public static UISetting Instance
    {
        //Instance가 존재하지 않는다면 바로 하나 생성한다.
        get
        {
            if(_instance != null)
            {
                return _instance;
            }

            _instance = Resources.Load<UISetting>("UISetting");

 #if UNITY_EDITOR
            if(_instance == null)
            {
                //UnityEditor에 포함된 클래스, 프로젝트 asset들을 관리해준다.
                if(!AssetDatabase.IsValidFolder(SettingFileDirectoy))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                //어떠한 이유로 동작하지 않을때 instace를 다시 할당한다.
                _instance = AssetDatabase.LoadAssetAtPath<UISetting>(SettingFilePath);

                if(_instance == null)
                {
                    //메모리로만 존재하기 떄문에 _instace에 할당
                    _instance = CreateInstance<UISetting>();
                    AssetDatabase.CreateAsset(_instance, SettingFilePath);
                }
            }
#endif
            
        return _instance;
        }
    }

    public string language = "kr";

    public Color themeColor;
    public Sprite emptyThumbnailSprite;
    public GameObject popupPrfab;

    public Font defaultFont;
    public int defaultFontSIze = 55;
    public Color defaultFontColor = Color.gray;
}
