using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComparable<T>
{
    ItemRelationshipType CompareTo( T other);
}
