﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ethereality.DoublyConnectedEdgeList
{
    public class Dcel<TEdge, TPoint>
        where TEdge : IEdge<TPoint>
        where TPoint : IEquatable<TPoint>
    {
        internal Dcel(
            IEnumerable<IVertex<TEdge, TPoint>> vertices,
            IEnumerable<IHalfEdge<TEdge, TPoint>> halfEdges,
            IEnumerable<IFace<TEdge, TPoint>> faces)
        {
            Vertices =
                vertices?.ToList() ?? throw new ArgumentNullException(nameof(vertices));

            HalfEdges =
                halfEdges?.ToList() ?? throw new ArgumentNullException(nameof(halfEdges));

            Faces =
                faces?.ToList() ?? throw new ArgumentNullException(nameof(faces));
        }

        public IHalfEdge<TEdge, TPoint>? FindHalfEdge(TPoint pointA, TPoint pointB)
        {
            return HalfEdges.SingleOrDefault(
                halfEdge =>
                    halfEdge.Origin.OriginalPoint.Equals(pointA) &&
                    halfEdge.Next.Origin.OriginalPoint.Equals(pointB));
        }

        public IReadOnlyList<IVertex<TEdge, TPoint>> Vertices { get; }

        public IReadOnlyList<IHalfEdge<TEdge, TPoint>> HalfEdges { get; }

        public IReadOnlyList<IFace<TEdge, TPoint>> Faces { get; }
    }
}