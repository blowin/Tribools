using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Tribools
{
  [Serializable]
  public struct Tribool :
    IEquatable<Tribool>,
    IComparable<Tribool>,
    IEquatable<bool>,
    IComparable<bool>,
    IEquatable<bool?>,
    IComparable<bool?>,
    IEquatable<TriboolType>,
    IComparable<TriboolType>,
    IComparable,
    IStructuralEquatable,
    IStructuralComparable
  {
    public static readonly Tribool True = new Tribool(true);
    public static readonly Tribool False = new Tribool(false);
    public static readonly Tribool Indefinitely = new Tribool();

    private readonly TriboolType type;

    #region Properties

    public bool IsTrue
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get { return type.IsTrue(); }
    }

    public bool IsFalse
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get { return type.IsFalse(); }
    }

    public bool IsIndefinitely
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get { return type.IsIndefinitely(); }
    }

    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Tribool(bool val)
    {
      type = FromBool(val);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Tribool(Tribool tribool)
    {
      type = tribool.type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Tribool(TriboolType type)
    {
      this.type = type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Tribool(bool? val)
    {
      type = FromNullableBool(val);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Tribool x, Tribool y)
    {
      return x.type == y.type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Tribool x, Tribool y)
    {
      return x.type != y.type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Tribool x, Tribool y)
    {
      return x.type != y.type && x.IsTrue ||
             x.IsIndefinitely && y.IsFalse;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Tribool x, Tribool y)
    {
      return !(x > y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Tribool x, Tribool y)
    {
      return x.type == y.type ||
             x.IsTrue ||
             x.IsIndefinitely && y.IsFalse;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Tribool x, Tribool y)
    {
      return !(x >= y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tribool operator &(Tribool x, Tribool y)
    {
      var xIsTrue = x.IsTrue;
      var xIsIndefinitely = x.IsIndefinitely;

      if (x == y)
      {
        return xIsTrue ? True : xIsIndefinitely ? Indefinitely : False;
      }

      if (xIsIndefinitely && y.IsTrue || y.IsIndefinitely && xIsTrue)
      {
        return Indefinitely;
      }

      return False;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tribool operator |(Tribool x, Tribool y)
    {
      if (x.IsTrue || y.IsTrue)
        return True;

      if (x.IsIndefinitely || y.IsIndefinitely)
        return Indefinitely;

      return False;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tribool operator !(Tribool x)
    {
      return new Tribool(x.type.Not());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tribool operator ^(Tribool x, Tribool y)
    {
      if (x.type == y.type)
        return x;

      if (x.IsIndefinitely || y.IsIndefinitely)
        return Indefinitely;

      return new Tribool(true);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tribool operator ++(Tribool tribool)
    {
      return new Tribool(tribool.type.Up());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tribool operator --(Tribool tribool)
    {
      return new Tribool(tribool.type.Down());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
      return type.HashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetHashCode(IEqualityComparer comparer)
    {
      return GetHashCode();
    }

    #region To Methods

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
      return type.ToStr();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToStringNumber()
    {
      return type.ToStrNumber();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool? ToNullableBool()
    {
      return type.ToNullableBool();
    }

    #endregion

    #region Converters

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator true(Tribool value)
    {
      return value.IsTrue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator false(Tribool value)
    {
      return value.IsFalse;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Tribool(bool value)
    {
      return new Tribool(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Tribool(int value)
    {
      return value == 0 ? False :
        value == 1 ? True :
        Indefinitely;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator bool(Tribool value)
    {
      switch (value.type)
      {
        case TriboolType.True: return true;
        case TriboolType.False: return false;
        default: throw new InvalidCastException();
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator TriboolType(Tribool value)
    {
      return value.type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Tribool(TriboolType value)
    {
      return new Tribool(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryParse(out bool val)
    {
      switch (type)
      {
        case TriboolType.True:
          val = true;
          return true;
        case TriboolType.False:
          val = false;
          return true;
        default:
          val = false;
          return false;
      }
    }

    #endregion

    #region Helper methos

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TriboolType FromNullableBool(bool? val)
    {
      return val.HasValue ? FromBool(val.Value) : TriboolType.Indefinitely;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TriboolType FromBool(bool val)
    {
      return val ? TriboolType.True : TriboolType.False;
    }

    #endregion
    
    #region CompareTo

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Tribool other)
    {
      return type > other.type ? 1 :
        type == other.type ? 0 : -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(bool other)
    {
      return CompareTo(new Tribool(other));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(bool? other)
    {
      return CompareTo(new Tribool(other));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(object other, IComparer comparer)
    {
      return CompareTo(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(object obj)
    {
      return !(obj is Tribool) ? 1 : CompareTo((Tribool) obj);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(TriboolType other)
    {
      return CompareTo(new Tribool(other));
    }

    #endregion

    #region Equals

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Tribool other)
    {
      return type == other.type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(bool other)
    {
      return Equals(new Tribool(other));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(bool? other)
    {
      return Equals(new Tribool(other));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(TriboolType other)
    {
      return Equals(new Tribool(other));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object other)
    {
      return other != null &&
             other is Tribool &&
             Equals((Tribool) other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(object other, IEqualityComparer comparer)
    {
      if (!(other is Tribool))
        return false;

      return type == ((Tribool) other).type;
    }

    #endregion
  }
}