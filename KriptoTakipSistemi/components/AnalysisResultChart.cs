using KriptoTakipSistemi.singleton;
using System.Windows;
using System.Windows.Forms;
using Color = System.Windows.Media.Color;

namespace KriptoTakipSistemi.components
{
    public partial class AnalysisResultChart : UserControl
    {

        public AnalysisResultChart()
        {
            InitializeComponent();
            SetStyle();
            CreateEventLinks();
        }
        private void CreateEventLinks()
        {
            ThemeController.Instance.ThemeChanged += SetStyle;
        }
        private void SetStyle()
        {
            label1.Font = ThemeController.Instance.HEADER_FONT;
            label1.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;

            AnalysisResultPanel.Font = ThemeController.Instance.HEADER_FONT;
            AnalysisResultPanel.Base.LabelsVisibility = Visibility.Collapsed;
            AnalysisResultPanel.LabelFormatter = value => "";

            AnalysisResultPanel.From = 0;
            AnalysisResultPanel.To = 100;
            AnalysisResultPanel.FromColor = Color.FromArgb(a: 100, r: 255, g: 0, b: 0);
            AnalysisResultPanel.ToColor = Color.FromArgb(a: 100, r: 48, g: 255, b: 0);
        }

        private void ChangeText()
        {

            if (AnalysisResultPanel.Value < 20)
            {
                //label1.Text = "Güçlü sat";
                AnalysisResultPanel.LabelFormatter = value => "Güçlü sat";

            }
            else if (AnalysisResultPanel.Value >= 20 && AnalysisResultPanel.Value < 45)
            {
                //label1.Text = "Sat";
                AnalysisResultPanel.LabelFormatter = value => "Sat";
            }
            else if (AnalysisResultPanel.Value >= 45 && AnalysisResultPanel.Value < 55)
            {
                //label1.Text = "Nötr";
                AnalysisResultPanel.LabelFormatter = value => "Nötr";
            }
            else if (AnalysisResultPanel.Value >= 55 && AnalysisResultPanel.Value < 80)
            {
                //label1.Text = "Al";
                AnalysisResultPanel.LabelFormatter = value => "Al";
            }
            else if (AnalysisResultPanel.Value >= 80 && AnalysisResultPanel.Value < 100)
            {
                //label1.Text = "Güçlü al";
                AnalysisResultPanel.LabelFormatter = value => "Güçlü al";
            }
        }

        public void SetValue(int value)
        {
            AnalysisResultPanel.Value = value;
            ChangeText();
        }
    }
}
