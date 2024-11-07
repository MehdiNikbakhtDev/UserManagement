using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class MetaData: BaseEntity
{
    public string TableName { get; set; }
    public string FieldName { get; set; }
    public int Value { get; set; }
    public string ValueCh { get; set; }
    public string Description { get; set; }
}
