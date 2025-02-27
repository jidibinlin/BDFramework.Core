﻿using System;
using BDFramework.Core.Tools;
using BDFramework.Editor.Tools;
using LitJson;
using UnityEditor;
using UnityEngine;

namespace BDFramework.Editor.Table
{
    public class EditorWindow_Table : EditorWindow
    {
        [MenuItem("BDFrameWork工具箱/3.表格/表格预览", false, (int) BDEditorGlobalMenuItemOrderEnum.BuildPackage_Table_GenSqlite - 1)]
        public static void Open()
        {
            var win = EditorWindow.GetWindow<EditorWindow_Table>();
            win.Show();
        }

        public void OnGUI()
        {
            if (BDEditorApplication.BDFrameworkEditorSetting == null)
            {
                return;
            }
            var BuildSqlSetting = BDEditorApplication.BDFrameworkEditorSetting.BuildSqlSetting;
            GUILayout.BeginVertical();
            GUILayout.Label("3.表格打包", EditorGUIHelper.LabelH2);
            GUILayout.Space(5);
            if (GUILayout.Button("表格导出成Sqlite", GUILayout.Width(300), GUILayout.Height(30)))
            {
                //3.打包表格
                Excel2SQLiteTools.AllExcel2SQLite(Application.streamingAssetsPath, BApplication.RuntimePlatform);
                Excel2SQLiteTools.CopySqlToOther(Application.streamingAssetsPath, BApplication.RuntimePlatform);
            }

            GUILayout.Space(10);
            if (BuildSqlSetting != null)
            {
                BuildSqlSetting.IsForceImportChangedExcelOnWillEnterPlaymode = EditorGUILayout.Toggle("PlayMode强制导表", BuildSqlSetting.IsForceImportChangedExcelOnWillEnterPlaymode);
                BuildSqlSetting.IsAutoImportSqlWhenExcelChange = EditorGUILayout.Toggle("Excel修改自动导表", BuildSqlSetting.IsAutoImportSqlWhenExcelChange);
            }
            GUILayout.EndVertical();
        }

        /// <summary>
        /// 重写
        /// </summary>
        new public void Show()
        {
            //计算hash
            var (hash, hashmap) = ExcelEditorTools.GetExcelsHash();
            Debug.Log(hash);
            Debug.Log("表格hash预览:"+JsonMapper.ToJson(hashmap, true));
            // //获取差异文件
            // var changeExcelList = ExcelEditorTools.GetChangedExcels();
            //
            // //保存
            // if (changeExcelList.Count > 0)
            // {
            //
            //     for (int i = 0; i < changeExcelList.Count; i++)
            //     {
            //         changeExcelList[i] = AssetDatabase.GUIDToAssetPath(changeExcelList[i]);
            //     }
            //     
            //     Debug.Log("变动的Excel文件:" + JsonMapper.ToJson(changeExcelList, true));
            //     ExcelEditorTools.SaveExcelCacheInfo(hashmap);
            // }
            // else
            // {
            //     Debug.Log("无变动的文件:" + JsonMapper.ToJson(changeExcelList, true));
            // }

            //显示
            base.Show();
        }


        private void OnDisable()
        {
            BDEditorApplication.BDFrameworkEditorSetting.Save();
        }
    }
}
