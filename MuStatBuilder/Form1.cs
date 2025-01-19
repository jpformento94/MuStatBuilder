using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using static System.Windows.Forms.AxHost;

namespace MuStatBuilder
{
    public partial class Window : Form
    {
        private CharactersList _charactersList;
        public double stats;

        // Cosas a hacer al inicializar la ventana principal
        public Window()
        {
            InitializeComponent();
            // Cargar los datos del JSON al iniciar
            _charactersList = CharactersList.LoadFromJson("characters.json");
        }

        // Funcion para mostrar por pantalla un personaje y sus tipos
        private void DisplayCharacterInfo(string characterName, double n)
        {
            // Buscar el personaje por su nombre
            var character = _charactersList.GetCharacterByName(characterName);

            if (character != null)
            {
                // Limpiar el consoletext antes de mostrar nueva información
                consoleText.Clear();

                // Construir la información del personaje
                consoleText.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
                consoleText.AppendText($"{character.name}\n");

                // Si es Dark Lord muestro las estadisticas con commando
                if (character.name.Equals("Dark Lord"))
                {
                    foreach (var type in character.types)
                    {
                        consoleText.SelectionFont = new Font("Arial", 10, FontStyle.Italic);
                        consoleText.AppendText($"  Type: {type.type}\n");

                        consoleText.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                        consoleText.AppendText($"    Strength: {type.strength * n}\n");
                        consoleText.AppendText($"    Agility: {type.agility * n}\n");
                        consoleText.AppendText($"    Vitality: {type.vitality * n}\n");
                        consoleText.AppendText($"    Energy: {type.energy * n}\n");
                        consoleText.AppendText($"    Commando: {type.commando * n}\n");
                    }
                }
                // Si no muestro las estadisticas normales
                else
                {
                    foreach (var type in character.types)
                    {
                        consoleText.SelectionFont = new Font("Arial", 10, FontStyle.Italic);
                        consoleText.AppendText($"  Type: {type.type}\n");

                        consoleText.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                        consoleText.AppendText($"    Strength: {type.strength * n}\n");
                        consoleText.AppendText($"    Agility: {type.agility * n}\n");
                        consoleText.AppendText($"    Vitality: {type.vitality * n}\n");
                        consoleText.AppendText($"    Energy: {type.energy * n}\n");
                    }
                }
            }
            else
            {
                // Mostrar un mensaje si el personaje no se encuentra
                consoleText.Text = $"Character '{characterName}' not found!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bCalcular_Click(object sender, EventArgs e)
        {

        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Obtener el personaje "Dark Knight"
        private void bDK_Click(object sender, EventArgs e)
        {
            if (textStats.Text != "")
            {
                stats = double.Parse(textStats.Text);
                DisplayCharacterInfo("Dark Knight", stats);
            }
            else 
            {
                MessageBox.Show("Stats is empty", "Error");
            }
        }

        private void bDW_Click(object sender, EventArgs e)
        {
            DisplayCharacterInfo("Dark Wizard", stats);
        }

        private void bFE_Click(object sender, EventArgs e)
        {
            DisplayCharacterInfo("Fairy Elf", stats);
        }

        private void bMG_Click(object sender, EventArgs e)
        {
            DisplayCharacterInfo("Magic Gladiator", stats);
        }

        private void bDL_Click(object sender, EventArgs e)
        {
            DisplayCharacterInfo("Dark Lord", stats);
        }

        private void textStats_TextChanged(object sender, EventArgs e)
        {
        }

        //Valida que solo se ingresen numeros en el TextBox
        private void textStats_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter
            }
        }
    }
}
