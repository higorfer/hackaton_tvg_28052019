using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Empresa.Sistema.Infra.Model
{
    [Table("users")]
    public class User
    {

        public long? Id { get; set; }
        public string Login { get; set; }
        public string AccessKey { get; set; }
    }
}
