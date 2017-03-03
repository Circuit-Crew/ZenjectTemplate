using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject.Editor
{
    public class TemplateObjectCreatorWindow : ZenjectEditorWindow
    {
        [MenuItem("Window/Secret Crush/Zenject/Template Creator")]
        public static TemplateObjectCreatorWindow GetOrCreateWindow()
        {
            var window = GetWindow<TemplateObjectCreatorWindow>();
            window.titleContent = new GUIContent("TemplateCreator");
            return window;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TemplateObjectCreator>().AsSingle();
        }
    }

    internal class TemplateObjectCreator : IGuiRenderable
    {
        private string _sourcePath;
        private string _targetPath;
        private string _oldName = "DerivedObjectTemplate";
        private string _newObjectName;

        public void GuiRender()
        {
            _sourcePath = EditorGUILayout.TextField(new GUIContent("Source path", "Absolute path to the template folder"), _sourcePath);

            if (GUILayout.Button("Get") && (_sourcePath != string.Empty))
                GetTemplateDir(_sourcePath);

            _targetPath = EditorGUILayout.TextField(
                new GUIContent("Target path", "Absolute path to the destination folder with intended folder name"), _targetPath);

            _oldName = EditorGUILayout.TextField(new GUIContent("Old Name", "Common name of the template files"), _oldName);
            _newObjectName = EditorGUILayout.TextField(new GUIContent("New Name", "New name for template files and classes using Regex"),
                _newObjectName);

            if (GUILayout.Button("Create") && (_newObjectName != string.Empty))
            {
                var di = new DirectoryInfo(_sourcePath);
                var target = new DirectoryInfo(_targetPath);
                CopyAll(di, target);
            }
        }

        private void GetTemplateDir(string root)
        {
            var dirs = new Stack<string>(20);

            if (!Directory.Exists(root))
                throw new ArgumentException();
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                var currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (DirectoryNotFoundException e)
                {
                    Debug.Log(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (DirectoryNotFoundException e)
                {
                    Debug.Log(e.Message);
                }

                if (files != null)
                {
                    foreach (var file in files)
                        try
                        {
                            var fi = new FileInfo(file);
                            if (((fi.Attributes & FileAttributes.Hidden) == 0) && !fi.Name.EndsWith(".meta"))
                                Debug.LogFormat("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                        }
                        catch (FileNotFoundException e)
                        {
                            Debug.Log(e.Message);
                        }
                }
                foreach (var subDir in subDirs)
                    dirs.Push(subDir);
            }
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
                Directory.CreateDirectory(target.FullName);

            // Copy each file into it’s new directory.
            foreach (var fi in source.GetFiles())
            {
                if (((fi.Attributes & FileAttributes.Hidden) != 0) || fi.Name.EndsWith(".meta")) continue;
                Debug.Log(string.Format(@"Copying {0}\{1}", target.FullName, fi.Name));

                var rgx = new Regex(_oldName);
                var result = fi.Name;
                result = rgx.Replace(result, _newObjectName);

                var newFile = fi.CopyTo(Path.Combine(target.ToString(), result), true);

                var stringContents = ReadStringFromFile(newFile);
                var replacedContents = stringContents;

                replacedContents = rgx.Replace(replacedContents, _newObjectName);

                // Because I'm bad at regex
                var lower = _oldName[0].ToString().ToLower() + _oldName.Substring(1);
                rgx = new Regex(lower);

                var lowerNew = _newObjectName[0].ToString().ToLower() + _newObjectName.Substring(1);
                replacedContents = rgx.Replace(replacedContents, lowerNew);

                File.WriteAllText(Path.Combine(newFile.DirectoryName, newFile.Name), replacedContents);
            }

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private string ReadStringFromFile(FileInfo fileInfo)
        {
            var file = fileInfo.Open(FileMode.Open);
            var data = new byte[file.Length];
            file.Read(data, 0, data.Length);
            file.Close();
            return Encoding.UTF8.GetString(data);
        }
    }
}