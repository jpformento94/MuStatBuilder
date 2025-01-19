using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MuStatBuilder
{
    public class CharactersList
    {
        public List<Character> Characters { get; set; }

        // Método para cargar desde un archivo JSON
        public static CharactersList LoadFromJson(string jsonPath)
        {
            string json = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<CharactersList>(json);
        }

        // Método para buscar un personaje por nombre
        public Character GetCharacterByName(string name)
        {
            return Characters.FirstOrDefault(c => c.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
