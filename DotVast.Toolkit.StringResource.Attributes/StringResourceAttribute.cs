﻿using System;

namespace DotVast.Toolkit.StringResource.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class StringResourceAttribute : Attribute
    {
        /// <summary>
        /// For example: "../Strings/Resources.resw"
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// For example: "GetLocalized"
        /// <para>
        /// Generator : public static ReswKey => "ReswKey".GetLocalized();
        /// </para>
        /// </summary>
        /// <remarks>
        /// Must set ExtensionMethodNamespace, if you set this.
        /// </remarks>
        public string? ExtensionMethod { get; set; }

        /// <summary>
        /// For example: "App.Extensions"
        /// <para>
        /// Generator : using App.Extensions;
        /// </para>
        /// </summary>
        public string? ExtensionMethodNamespace { get; set; }
    }
}
