using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inoxie.Tools.ApiServices.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NoUpdateAttribute : Attribute
{
}
