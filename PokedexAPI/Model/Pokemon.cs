using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexAPI.Models {
    [Table("Pokemon")]
    public class Pokemon {
        public int Id { get; set; }
        public int NumeroPokedex { get; set; }
        public string Name { get; set; }
        public string FrontSpriteUrl { get; set; }
        public string BackSpriteUrl { get; set; }
        public string FrontShinySpriteUrl { get; set; }
        public string BackShinySpriteUrl { get; set; }
        public string FirstType { get; set; }
        public string? SecondType { get; set; }
    }
}
