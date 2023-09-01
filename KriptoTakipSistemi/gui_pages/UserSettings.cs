using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KriptoTakipSistemi.gui_pages
{
    public partial class UserSettings : UserControl
    {
        List<THEME> themes;
        int nextIndex = 0;
        public UserSettings()
        {
            InitializeComponent();
            foreach (THEME theme in Enum.GetValues(typeof(THEME)))
            {
                if (themes == null)
                {
                    themes = new List<THEME>();
                }

                themes.Add(theme);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ThemeController.Instance.ChangeTheme(themes[nextIndex++]);
            if (nextIndex >= themes.Count)
            {
                nextIndex = 0;
            }
        }
    }
}
