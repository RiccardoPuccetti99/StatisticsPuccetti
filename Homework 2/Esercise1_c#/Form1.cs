using Microsoft.VisualBasic.FileIO;
using System.Data;
//codice di Riccardo Puccetti, non copiare e non clonare la repository
namespace Esercise1_c_
{
    public partial class Form1 : Form
    {
        private DataTable dataTable = new();
        private Dictionary<string, Dictionary<string, int>> jointDistribution = new();

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataTable.Columns.Add("Age");
            dataTable.Columns.Add("Height");
            dataTable.Columns.Add("Ambitious (0-5)");
            dataTable.Columns.Add("Dream Works");

            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //codice di Riccardo Puccetti, non copiare e non clonare la repository
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    try
                    {
                        //uso il TextFieldParser per effettuare il parsing del csv in ingresso
                        //https://stackoverflow.com/questions/2081418/parsing-csv-files-in-c-with-header
                        using TextFieldParser parser = new(selectedFile);
                        {

                            List<List<string>> extractedData = ExtractDataFromCSV(parser);

                            // popola la prima tabella
                            foreach (var row in extractedData)
                            {
                                dataTable.Rows.Add(row.ToArray());
                            }

                            // calcola la frequency distribution
                            Dictionary<string, Dictionary<string, int>> frequencyDistributions = ComputeFrequency(extractedData);

                            // popola la frequency distribution
                            PopulateFrequency(dataGridView2, frequencyDistributions["Age"]);
                            PopulateFrequency(dataGridView3, frequencyDistributions["Height"]);
                            PopulateFrequency(dataGridView4, frequencyDistributions["Ambitious (0-5)"]);
                            PopulateFrequency(dataGridView5, frequencyDistributions["Dream Works"]);

                            // calcola la joint distribution
                            jointDistribution = ComputeJoint(extractedData, "Age", "Ambitious (0-5)");

                            // popola la joint distribution
                            PopulateJoint(dataGridView6, jointDistribution);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private Dictionary<string, Dictionary<string, int>> ComputeFrequency(List<List<string>> data)
        {
            //codice di Riccardo Puccetti, non copiare e non clonare la repository
            //con questo dizionario posso:
            //1)salvare il nome della tabella corrispondente indicizzandolo
            //2)attraverso  il foreach setto tutti i valori che verranno aggiunti dentro il dizionario
            Dictionary<string, Dictionary<string, int>> frequencyDistributions = new();
            string[] columnNames = { "Age", "Height", "Ambitious (0-5)", "Dream Works" }; //mi seve per indicizzare

            foreach (string columnName in columnNames)
            {
                Dictionary<string, int> frequency = new();  //questo dizionario serve per per salvare le frequenze
                int columnIndex = dataTable.Columns.IndexOf(columnName); //mi permette di trovare l'indice della tabella utilizzando il nome
                //avrei anche potuto indicizzarlo manualmente e scorrere gli indici, tuttavia quando faccio
                // frequencyDistributions[columnName] = frequency;   mi permette di accedere facilmente alla chiave

                foreach (var row in data) //scorro le righe
                {
                    if (columnIndex < row.Count)  //mi assicuro che non provi ad accedere ad un elemento che non esiste
                    {
                        string value = row[columnIndex]; //accedo alla cella indicizzata da columnIndex

                        if (frequency.ContainsKey(value))  //semplicimente controlla se l'elemento è gia nel dizionario
                        {
                            frequency[value]++; //aumenta di uno se è già presente
                        }
                        else
                        {
                            frequency[value] = 1;  //lo setta ad uno inizializzando la chiave altrimenti
                        }
                    }
                }

                frequencyDistributions[columnName] = frequency; //appena ho finito per una tabella, posso aggiungere il dizionario con la chiave data dal nome della colonna
            }

            return frequencyDistributions;
        }

        private Dictionary<string, Dictionary<string, int>> ComputeJoint(List<List<string>> data, string variable1, string variable2)
        {
            //codice di Riccardo Puccetti, non copiare e non clonare la repository
            //questa funzione è molto simile all'altra di computazione, l'unica differenza è che considero direttamente 
            //i due indici delle colonne e vado direttamente a calcolare la frequenza
            //la situa
            Dictionary<string, Dictionary<string, int>> jointDistribution = new();

            int columnIndex1 = dataTable.Columns.IndexOf(variable1);
            int columnIndex2 = dataTable.Columns.IndexOf(variable2);

            foreach (var row in data)
            {
                if (columnIndex1 < row.Count && columnIndex2 < row.Count)
                {
                    string value1 = row[columnIndex1];
                    string value2 = row[columnIndex2];

                    if (!jointDistribution.ContainsKey(value1))
                    {
                        jointDistribution[value1] = new Dictionary<string, int>();
                    }

                    if (jointDistribution[value1].ContainsKey(value2))
                    {
                        //con questa linea di codice si va ad accedere al dizionario con chiave value1, alla quale si accede nuovamente
                        //ad un altro dizionario con chiave value2 e di cui viene aumentato il valore di 1 con ++
                        jointDistribution[value1][value2]++;
                    }
                    else
                    {
                        jointDistribution[value1][value2] = 1;
                    }
                }
            }

            return jointDistribution;
        }

        private static void PopulateFrequency(DataGridView dataGridView, Dictionary<string, int> frequency)
        {
            //codice di Riccardo Puccetti, non copiare e non clonare la repository
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Value", "Value");
            dataGridView.Columns.Add("Absolute Frequency", "Absolute Frequency");
            dataGridView.Columns.Add("Relative Frequency", "Relative Frequency");
            dataGridView.Columns.Add("Percentage", "Percentage");

            int total = frequency.Values.Sum();  //sommo il totale dei valori con la funzione Sum

            foreach (var temp in frequency)
            {
                string value = temp.Key;
                int absoluteFrequency = temp.Value;
                double relativeFrequency = Math.Round((double)absoluteFrequency / total, 2);  //arrotondo a 2 cifre dopo la virgola e calcolo la frequenza relativa
                double percentage = relativeFrequency * 100; //frequenza assoluta
                dataGridView.Rows.Add(value, absoluteFrequency, relativeFrequency, percentage + "%");
            }
        }

        private static void PopulateJoint(DataGridView dataGridView, Dictionary<string, Dictionary<string, int>> jointDistribution)
        {
            //codice di Riccardo Puccetti, non copiare e non clonare la repository
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Age", "Age");
            dataGridView.Columns.Add("Ambitious (0-5)", "Ambitious (0-5)");
            dataGridView.Columns.Add("Absolute Frequency", "Absolute Frequency");
            dataGridView.Columns.Add("Relative Frequency", "Relative Frequency");
            dataGridView.Columns.Add("Percentage", "Percentage");

            int total = jointDistribution.Values.Sum(innerDict => innerDict.Values.Sum());

            foreach (var temp in jointDistribution)
            {
                string age = temp.Key;

                foreach (var ambitioustemp in temp.Value)
                {
                    string ambitious = ambitioustemp.Key;
                    int absoluteFrequency = ambitioustemp.Value;
                    double relativeFrequency = Math.Round((double)absoluteFrequency / total, 2);
                    double percentage = relativeFrequency * 100;
                    dataGridView.Rows.Add(age, ambitious, absoluteFrequency, relativeFrequency, percentage + "%");
                }
            }
        }


        private static List<List<string>> ExtractDataFromCSV(TextFieldParser parser)
        {
            //codice di Riccardo Puccetti, non copiare e non clonare la repository
            //in questo metodo vengono estratte le colonne che mi servono così semplifico l'accesso ai dati 
            List<List<string>> extractedData = new List<List<string>>();

            try
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                //a differenza del file in javascript in cui era stato creato un algoritmo per il parsing che considerava le "
                //in questo progetto viene usata una libreria di c# permette di includere il caso particolare con la riga di codice scritta in seguito
                parser.HasFieldsEnclosedInQuotes = true;

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields != null && fields.Length >= 24)  //controllo se abbia almeno 24 colonne perchè dopo accedo alla 23
                    {
                        List<string> rowData = new()
                        {
                            fields[14], // Age
                            fields[16], // Height
                            fields[5],  // Ambitious (0-5)
                            fields[23]  // Dream Works
                        };
                        extractedData.Add(rowData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return extractedData;
        }
    }
}
