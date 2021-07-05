﻿using System;
using System.Diagnostics;

namespace Askaiser.UITesting
{
    [DebuggerDisplay("{Name}")]
    public sealed class ImageElement : IElement
    {
        private readonly string _name;
        private readonly byte[] _content;
        private readonly double _threshold;

        public ImageElement(string name, string base64Content, double threshold)
            : this(name, Convert.FromBase64String(base64Content), threshold)
        {
        }

        public ImageElement(string name, byte[] content, double threshold)
        {
            this.Name = name;
            this.Content = content;
            this.Threshold = threshold;
            this.Grayscale = false;
        }

        internal ImageElement(JsonImageElement json)
        {
            this.Name = json.Name;
            this.Content = Convert.FromBase64String(json.Content);
            this.Threshold = json.Threshold;
            this.Grayscale = json.Grayscale;
        }

        public string Name
        {
            get => this._name;
            init => this._name = value is { Length: > 0 } ? value : throw new ArgumentException("Name cannot be null or empty.", nameof(this.Name));
        }

        public byte[] Content
        {
            get => this._content;
            init => this._content = value is { Length: > 0 } ? value : throw new ArgumentException("Content must be a non-empty array of bytes.", nameof(this.Content));
        }

        public double Threshold
        {
            get => this._threshold;
            init => this._threshold = value is >= 0 or <= 1 ? value : throw new ArgumentOutOfRangeException(nameof(this.Threshold), "Threshold must be a floating number between 0 and 1.");
        }

        public bool Grayscale { get; init; }
    }
}