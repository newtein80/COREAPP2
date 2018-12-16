using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace COREAPP2.Domain.ValueObjects
{
    #region+ "NorthWind" Source: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right) != false;
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
    #endregion

    #region+ source: https://github.com/jhewlett/ValueObject
    //public abstract class ValueObject : IEquatable<ValueObject>
    //{
    //    private List<PropertyInfo> properties;
    //    private List<FieldInfo> fields;

    //    public static bool operator ==(ValueObject obj1, ValueObject obj2)
    //    {
    //        if (object.Equals(obj1, null))
    //        {
    //            if (object.Equals(obj2, null))
    //            {
    //                return true;
    //            }
    //            return false;
    //        }
    //        return obj1.Equals(obj2);
    //    }

    //    public static bool operator !=(ValueObject obj1, ValueObject obj2)
    //    {
    //        return !(obj1 == obj2);
    //    }

    //    public bool Equals(ValueObject obj)
    //    {
    //        return Equals(obj as object);
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null || GetType() != obj.GetType()) return false;

    //        return GetProperties().All(p => PropertiesAreEqual(obj, p))
    //            && GetFields().All(f => FieldsAreEqual(obj, f));
    //    }

    //    private bool PropertiesAreEqual(object obj, PropertyInfo p)
    //    {
    //        return object.Equals(p.GetValue(this, null), p.GetValue(obj, null));
    //    }

    //    private bool FieldsAreEqual(object obj, FieldInfo f)
    //    {
    //        return object.Equals(f.GetValue(this), f.GetValue(obj));
    //    }

    //    private IEnumerable<PropertyInfo> GetProperties()
    //    {
    //        if (this.properties == null)
    //        {
    //            this.properties = GetType()
    //                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
    //                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
    //                .ToList();

    //            // Not available in Core
    //            // !Attribute.IsDefined(p, typeof(IgnoreMemberAttribute))).ToList();
    //        }

    //        return this.properties;
    //    }

    //    private IEnumerable<FieldInfo> GetFields()
    //    {
    //        if (this.fields == null)
    //        {
    //            this.fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
    //                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
    //                .ToList();
    //        }

    //        return this.fields;
    //    }

    //    public override int GetHashCode()
    //    {
    //        unchecked   //allow overflow
    //        {
    //            int hash = 17;
    //            foreach (var prop in GetProperties())
    //            {
    //                var value = prop.GetValue(this, null);
    //                hash = HashValue(hash, value);
    //            }

    //            foreach (var field in GetFields())
    //            {
    //                var value = field.GetValue(this);
    //                hash = HashValue(hash, value);
    //            }

    //            return hash;
    //        }
    //    }

    //    private int HashValue(int seed, object value)
    //    {
    //        var currentHash = value != null
    //            ? value.GetHashCode()
    //            : 0;

    //        return seed * 23 + currentHash;
    //    }
    //}
    #endregion
}
