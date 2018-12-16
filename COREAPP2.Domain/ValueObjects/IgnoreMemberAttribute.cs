using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Domain.ValueObjects
{
    // source: https://github.com/jhewlett/ValueObject
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
