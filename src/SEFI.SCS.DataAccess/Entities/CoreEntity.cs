using Newtonsoft.Json;
using SEFI.Encryption;
namespace SEFI.Domain.Entities
{
    public class CoreEntity
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public virtual string Identifier { get => KeyGenerator.EncryptKey(Id); set => Id = KeyGenerator.DecryptKey(value); }
    }
}
