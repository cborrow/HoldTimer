using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Reflection;

namespace HoldTimer
{
    public class ThemeLoader
    {
        static ThemeLoader instance;
        public static ThemeLoader Instance
        {
            get { return instance; }
        }

        public string ThemesDirPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "Themes");

        List<Theme> loadedThemes = new List<Theme>();
        public List<Theme> LoadedThemes
        {
            get { return loadedThemes; }
        }

        Theme activeTheme;
        public Theme ActiveTheme
        {
            get { return activeTheme; }
        }

        public ThemeLoader()
        {
            instance = this;
        }

        public void LoadThemes()
        {
            //Clear any existing themes and load default theme, followed by any in Themes folder
            loadedThemes.Clear();
            loadedThemes.Add(new Theme());

            if (!Directory.Exists(ThemesDirPath)) //No themes folder. Don't worry about it
                return;

            foreach(string themeFile in Directory.GetFiles(ThemesDirPath, "*.xml"))
            {
                Theme theme = LoadTheme(themeFile);

                if (theme != null && theme.Name.ToLower() != "default")
                    loadedThemes.Add(theme);
            }
        }

        public void SetActiveTheme(Theme theme)
        {
            if (!loadedThemes.Contains(theme))
                loadedThemes.Add(theme);

            activeTheme = theme;
        }

        public void SetActiveTheme(string name)
        {
            for (int i = 0; i < loadedThemes.Count; i++)
            {
                if (loadedThemes[i].Name == name)
                {
                    activeTheme = loadedThemes[i];
                    break;
                }
            }
        }

        protected Theme LoadTheme(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            Theme theme = new Theme();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlElement root = doc.DocumentElement;

            foreach(XmlAttribute xmlAttr in root.Attributes)
            {
                if (xmlAttr.Name == "Name")
                    theme.Name = xmlAttr.Value;
                else if (xmlAttr.Name == "Description")
                    theme.Description = xmlAttr.Value;
            }

            foreach (XmlNode cNode in root.GetElementsByTagName("Color"))
            {
                if (cNode.Attributes.Count == 2)
                {
                    if (cNode.Attributes[0].Name == "Name")
                    {
                        if (cNode.Attributes[1].Name == "Value")
                        {
                            string name = cNode.Attributes[0].Value;
                            Color color = ColorTranslator.FromHtml(cNode.Attributes[1].Value);

                            if (theme.GetType().GetProperty(name) != null)
                            {
                                PropertyInfo pi = theme.GetType().GetProperty(name);
                                pi.SetValue(theme, color, null);
                            }
                        }
                    }
                }
            }

            return theme;
        }
    }
}
