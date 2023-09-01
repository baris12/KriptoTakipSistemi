using System;
using System.Drawing;
using System.Windows.Forms;

namespace KriptoTakipSistemi.singleton
{
    internal class ThemeController
    {
        private static ThemeController _instance;
        public static ThemeController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThemeController();
                }
                return _instance;
            }
        }

        public event Action ThemeChanged;

        public Font DEFAULT_FONT = new Font("Nirmala UI", 9, FontStyle.Bold);
        public Font HEADER_FONT = new Font("Nirmala UI", 15, FontStyle.Bold);


        //DEFAULT THEME
        public Color COLOR_LAYER_1 = ColorTranslator.FromHtml("#1B3133"); // background and panel
        public Color COLOR_LAYER_2 = ColorTranslator.FromHtml("#3F4B4D"); // active buttons and highligted panels
        public Color COLOR_LAYER_3 = ColorTranslator.FromHtml("#6A7E80"); // borders
        public Color COLOR_LAYER_4 = ColorTranslator.FromHtml("#447B80"); // not using yet
        public Color COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#BBBDBD");
        public Color COLOR_LABEL_DARK = ColorTranslator.FromHtml("#E8080");

        public void ChangeTheme(THEME theme)
        {
            if (theme == THEME.GREEN || theme == THEME.DEFAULT)
            {
                COLOR_LAYER_1 = ColorTranslator.FromHtml("#1B3133");
                COLOR_LAYER_2 = ColorTranslator.FromHtml("#3F4B4D");
                COLOR_LAYER_3 = ColorTranslator.FromHtml("#6A7E80");
                COLOR_LAYER_4 = ColorTranslator.FromHtml("#447B80");
                COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#BBBDBD");
                COLOR_LABEL_DARK = ColorTranslator.FromHtml("#E8080");
                ThemeChanged?.Invoke();
            }
            else if (theme == THEME.BLUE)
            {
                COLOR_LAYER_1 = ColorTranslator.FromHtml("#272942");
                COLOR_LAYER_2 = ColorTranslator.FromHtml("#3844C2");
                COLOR_LAYER_3 = ColorTranslator.FromHtml("#29328F");
                COLOR_LAYER_4 = ColorTranslator.FromHtml("#78FCC");
                COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#BBBDBD");
                COLOR_LABEL_DARK = ColorTranslator.FromHtml("#E8080");
                ThemeChanged?.Invoke();
            }
            else if (theme == THEME.BROWN)
            {
                COLOR_LAYER_1 = ColorTranslator.FromHtml("#282312");
                COLOR_LAYER_2 = ColorTranslator.FromHtml("#223615");
                COLOR_LAYER_3 = ColorTranslator.FromHtml("#402F19");
                COLOR_LAYER_4 = ColorTranslator.FromHtml("#403F19");
                COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#BBBDBD");
                COLOR_LABEL_DARK = ColorTranslator.FromHtml("#E8080");
                ThemeChanged?.Invoke();
            }
            else if (theme == THEME.GRAY)
            {
                COLOR_LAYER_1 = ColorTranslator.FromHtml("#303030");
                COLOR_LAYER_2 = ColorTranslator.FromHtml("#444545");
                COLOR_LAYER_3 = ColorTranslator.FromHtml("#7E8080");
                COLOR_LAYER_4 = ColorTranslator.FromHtml("#BBBDBD");
                COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#BBBDBD");
                COLOR_LABEL_DARK = ColorTranslator.FromHtml("#E8080");
                ThemeChanged?.Invoke();
            }
            else if (theme == THEME.LIGHT)
            {
                COLOR_LAYER_1 = ColorTranslator.FromHtml("#FAFEF7");
                COLOR_LAYER_2 = ColorTranslator.FromHtml("#E6FFEF");
                COLOR_LAYER_3 = ColorTranslator.FromHtml("#E5E8D1");
                COLOR_LAYER_4 = ColorTranslator.FromHtml("#D1E8D1");
                COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#2B2B2A");
                COLOR_LABEL_DARK = ColorTranslator.FromHtml("#2B2B2A");
                ThemeChanged?.Invoke();
            }
            else if (theme == THEME.LIGHT2)
            {
                COLOR_LAYER_1 = ColorTranslator.FromHtml("#E7EBE4");
                COLOR_LAYER_2 = ColorTranslator.FromHtml("#AEC2AF");
                COLOR_LAYER_3 = ColorTranslator.FromHtml("#CCE3D5");
                COLOR_LAYER_4 = ColorTranslator.FromHtml("#D1D4BE");
                COLOR_LABEL_BRIGHT = ColorTranslator.FromHtml("#2B2B2A");
                COLOR_LABEL_DARK = ColorTranslator.FromHtml("#2B2B2A");
                ThemeChanged?.Invoke();
            }
        }

        public void SetButtonStyle(Button button, bool activeStyle)
        {
            button.BackColor = activeStyle ? ThemeController.Instance.COLOR_LAYER_2 : ThemeController.Instance.COLOR_LAYER_1;
            button.FlatAppearance.BorderColor = ThemeController.Instance.COLOR_LAYER_1;
            button.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
            button.Font = ThemeController.Instance.DEFAULT_FONT;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
        }

        public void SetLabelStyle(Label label)
        {
            label.Font = ThemeController.Instance.DEFAULT_FONT;
            label.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
        }
        public void SetBigLableStyle(Label label)
        {
            label.Font = ThemeController.Instance.HEADER_FONT;
            label.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
        }
        public void SetPanelStyle(Panel panel)
        {
            panel.BackColor = ThemeController.Instance.COLOR_LAYER_1;
        }

        public void SetFormStyle(Form form)
        {
            form.BackColor = ThemeController.Instance.COLOR_LAYER_1;
        }

        public void SetDataGridStyle(DataGridView dataGrid)
        {
            DataGridViewCellStyle rowsDefaultStyle = new DataGridViewCellStyle
            {
                BackColor = ThemeController.Instance.COLOR_LAYER_1,
                ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT,
                SelectionForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT,
                SelectionBackColor = ThemeController.Instance.COLOR_LAYER_2
            };

            dataGrid.RowsDefaultCellStyle = rowsDefaultStyle;
            dataGrid.AlternatingRowsDefaultCellStyle = rowsDefaultStyle;
            dataGrid.ColumnHeadersDefaultCellStyle = rowsDefaultStyle;

            dataGrid.BackgroundColor = ThemeController.Instance.COLOR_LAYER_1;
            dataGrid.GridColor = Color.Black;
            dataGrid.RowHeadersVisible = false;
            dataGrid.ColumnHeadersHeight = 23;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }



    }
}
