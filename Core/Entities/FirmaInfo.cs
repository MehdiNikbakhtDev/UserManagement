using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities;

public class FirmaInfo:BaseEntity
{
    public int Type { get; set; }
    public string Value { get; set; }
}
