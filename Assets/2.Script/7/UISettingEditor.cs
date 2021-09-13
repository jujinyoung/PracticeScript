using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UISetting))]
public class UISettingEditor : Editor
{
    //해당메뉴를 선택하면 실행
    [MenuItem("Assets/Open UI Setting")]
    public static void OpenInspector()
    {
        Selection.activeObject = UISetting.Instance;
    }

    //가끔 scriptableObject에 변경사항 저장이 지연될떄 사용하는 코드
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUI.changed)
        {
            //지연시간을 강제적으로 동기화시킴
            EditorUtility.SetDirty(target);
            //crtl + s를 안눌러도 저장사항이 저장되도록
            AssetDatabase.SaveAssets();
        }
    }
}
