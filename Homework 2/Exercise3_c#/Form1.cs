using System.Windows.Forms.DataVisualization.Charting;

namespace Exercise3_c_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDown1.Value;
            int k = (int)numericUpDown2.Value;

            var data = PlotDistribution(N, k);

            chart1.Series.Clear();

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Distribution");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            double columnWidth = 1.0 / k;

            for (int i = 0; i < data.Length; i++)
            {
                double xValue = i * columnWidth + (columnWidth / 2);

                DataPoint dataPoint = new DataPoint(xValue, data[i]);
                series.Points.Add(dataPoint);
            }

            chart1.Series.Add(series);

            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            for (int i = 0; i < k; i++)
            {
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(
                    i * columnWidth + (columnWidth / 2),
                    (i + 1) * columnWidth + (columnWidth / 2),
                    $"[{i * (1.0 / k):F2}, {(i + 1) * (1.0 / k):F2}]"
                );
            }
        }




        private int[] PlotDistribution(int N, int k)
        {
            int[] distributionData = new int[k];
            Random random = new Random();

            for (int i = 0; i < N; i++)
            {
                double randomNumber = random.NextDouble();
                int interval = (int)(randomNumber * k);
                distributionData[interval]++;
            }

            return distributionData;
        }
    }
}
