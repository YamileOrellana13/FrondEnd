using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListView.Models
{
    class Paises
    {
        #region Atributos
        [JsonProperty(PropertyName = "name")]           // los de rojo tienen que ser lo mismo que la api y los string de abajo puede ser igual o en mayuscula
        public string Name { get; set; }

        [JsonProperty(PropertyName = "population")]
        public int Population { get; set; }

        [JsonProperty(PropertyName = "capital")]
        public string Capital { get; set; }
        #endregion
    }
}
